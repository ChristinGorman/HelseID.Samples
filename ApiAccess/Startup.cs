using System.IdentityModel.Tokens.Jwt;
using HelseId.Samples.ApiAccess.AccessTokenUpdaters;
using HelseId.Samples.ApiAccess.Configuration;
using HelseId.Samples.ApiAccess.Interfaces.AccessTokenUpdaters;
using HelseId.Samples.ApiAccess.Interfaces.Stores;
using HelseId.Samples.ApiAccess.Stores;
using HelseId.Samples.ApiAccess.ViewModels;
using HelseId.Samples.Common.ApiConsumers;
using HelseId.Samples.Common.ClientAssertions;
using HelseId.Samples.Common.Configuration;
using HelseId.Samples.Common.Endpoints;
using HelseId.Samples.Common.Interfaces.ApiConsumers;
using HelseId.Samples.Common.Interfaces.ClientAssertions;
using HelseId.Samples.Common.Interfaces.Endpoints;
using HelseId.Samples.Common.Interfaces.JwtTokens;
using HelseId.Samples.Common.Interfaces.PayloadClaimsCreators;
using HelseId.Samples.Common.Interfaces.TokenExpiration;
using HelseId.Samples.Common.Interfaces.TokenRequests;
using HelseId.Samples.Common.JwtTokens;
using HelseId.Samples.Common.PayloadClaimsCreators;
using HelseId.Samples.Common.TokenExpiration;
using HelseId.Samples.Common.TokenRequests;
using HelseID.Samples.Configuration;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;

namespace HelseId.Samples.ApiAccess;

public class Startup
{
    public const string SecurityLevelClaimPolicy = "SecurityLevelClaimPolicy";

    private readonly Settings _settings;

    public Startup(Settings settings)
    {
        _settings = settings;
    }
    
    public WebApplication BuildWebApplication()
    {
        var builder = WebApplication.CreateBuilder();

        ConfigureHttpServer(builder);

        ConfigureServices(builder.Services);

        DisableDefaultNamespaces();

        var webApplication = builder.Build();
        return Configure(webApplication);
    }

    private void ConfigureHttpServer(WebApplicationBuilder builder)
    {
        // Sets the server to use the port that is described in ConfigurationValues.
        const int serverPort = ConfigurationValues.ApiAccessWebServerPort;
        builder.WebHost.UseKestrel(kestrelServerOptions =>
        {
            // Bind directly to a socket handle or Unix socket
            kestrelServerOptions.ListenLocalhost(serverPort, listenOptions => listenOptions.UseHttps());
        });
    }

    private void DisableDefaultNamespaces()
    {
        // Disables default namespaces added by ASP.NET Core, and uses the exact claims created with the OpenID Server instead,
        // e.g. 'given_name' gets converted to 'http://schemas.xmlsoap.org/ws/2005/05/identity/claims/givenname'
        JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
    }

    private void ConfigureServices(IServiceCollection services) 
    {
        // Add services to the container.
        services.AddControllersWithViews();

        // Create singletons from instances. These can be injected into other objects, for instance the HomeController 
        services.AddSingleton<Settings>(_settings);
        // We need the HelseIdConfiguration instance as a service as well:
        services.AddSingleton<HelseIdConfiguration>(_settings.HelseIdConfiguration);

        // Services for calculating the expiration time for tokens
        var dateTimeService = new DateTimeService();
        services.AddSingleton<IDateTimeService>(dateTimeService);
        services.AddSingleton<IExpirationTimeCalculator, ExpirationTimeCalculator>();

        // Payload claim creators for use when creating a request object
        if (_settings.ClientType == ClientType.ApiAccessWithRequestObject)
        {
            // We need payload claims for the token request, both the "default" type and for the child organization number:
            var compositePayloadClaimsCreator = new CompositePayloadClaimsCreator(new List<IPayloadClaimsCreator>
            {
                new RequestObjectPayloadClaimsCreator(dateTimeService),
                new PayloadClaimsCreatorWithChildOrgNumber()
            });
            // We add this object as an instance of IPayloadClaimsCreatorForClientAssertion
            services.AddSingleton<IPayloadClaimsCreatorForRequestObjects>(compositePayloadClaimsCreator);
        }
        else
        {
            // No request object is needed, so we inject a null object for payload claims creation instead
            services.AddSingleton<IPayloadClaimsCreatorForRequestObjects>(new NullPayloadClaimsCreatorForRequestObjects());
        }

        // We only need the "default" token request payload claim creator:
        services.AddSingleton<IPayloadClaimsCreatorForClientAssertion, ClientAssertionPayloadClaimsCreator>();
        
        // Builder for client assertions payloads
        services.AddSingleton<IJwtPayloadCreator, JwtPayloadCreator>();
        // Builder for JWT tokens used for client assertions
        services.AddSingleton<ISigningJwtTokenCreator, SigningJwtTokenCreator>();
        // Builder for client assertions
        services.AddSingleton<IClientAssertionsBuilder, ClientAssertionsBuilder>();
        // Finds the relevant endpoints on the HelseID server
        services.AddSingleton<IDiscoveryDocumentGetter>(new DiscoveryDocumentGetter(_settings.HelseIdConfiguration.StsUrl));
        services.AddSingleton<IHelseIdEndpointsDiscoverer, HelseIdEndpointsDiscoverer>();
        // Builds token requests (in our case, refresh token requests)
        services.AddSingleton<ITokenRequestBuilder, TokenRequestBuilder>();
        // Used for creating a simple view model
        services.AddSingleton<IViewModelCreator, ViewModelCreator>();
        
        // Updates the stored access token(s) by means of the refresh token grant
        services.AddSingleton<IAccessTokenUpdater, AccessTokenUpdater>();
        
        // An API consumer, calls the sample API(s)
        services.AddSingleton<IApiConsumer, ApiConsumer>();
        // A store for user sessions, in this case "mocked" as a memory store
        services.AddSingleton<IUserSessionDataStore, MemoryUserSessionDataStore>();
        // A getter of user session data, uses the user session data store
        services.AddSingleton<IUserSessionGetter, UserSessionGetter>();

        // Add the authentication options initializers:
        services.AddSingleton<IConfigureOptions<AuthenticationOptions>, AuthenticationOptionsInitializer>();
        services.AddSingleton<IConfigureNamedOptions<OpenIdConnectOptions>, OpenIdConnectOptionsInitializer>();
        
        // Set authentication options (these will call the AuthenticationOptionsInitializer and OpenIdConnectOptionsInitializer instances)
        services.AddAuthentication()
            .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
            {
                // Path to access denied endpoint. Used when authorization fails
                options.AccessDeniedPath = "/authorization/access-denied";
            })
            .AddOpenIdConnect(openIdConnectOptions =>
            {
                // We need to extract the OpenID Connect options initializer from the service provider:
                var serviceProvider = services.BuildServiceProvider();
                var  initializer = serviceProvider.GetService<IConfigureNamedOptions<OpenIdConnectOptions>>();
                initializer!.Configure(nameof(OpenIdConnectOptionsInitializer), openIdConnectOptions);
            });

        var securityLevelClaimPolicy = new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .RequireClaim(ConfigurationValues.HelseIdSecurityLevelClaim, "4")
                .Build();

        services.AddAuthorization(config =>
        {
            config.AddPolicy(SecurityLevelClaimPolicy, securityLevelClaimPolicy);
        });
    }

    private WebApplication Configure(WebApplication webApplication) 
    {
        // Configure the HTTP request pipeline.
        if (!webApplication.Environment.IsDevelopment())
        {
            webApplication.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            webApplication.UseHsts();
        }

        webApplication.UseHttpsRedirection();
        webApplication.UseStaticFiles();
        webApplication.UseRouting();
        // Registers the authentication middleware:
        webApplication.UseAuthentication(); 
        webApplication.UseAuthorization();
        webApplication.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");
        return webApplication;
    }
}