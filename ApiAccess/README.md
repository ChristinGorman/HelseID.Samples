## User Authentication Sample with API access

This code example does two things:
* It logs on a user by using the [Authorization Code Flow](https://openid.net/specs/openid-connect-core-1_0.html#CodeFlowAuth)
* You can also connect to the sample API by using an access token

### Prerequisites
If you want to use HelseID not only to log on as a user, but also to connect to an API, you'll need to run the [Sample API](../SampleAPI/README.md):

* Go to the `SampleAPI` folder and run the commando `dotnet run`.


### Architecture

The client application is based on [ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/?view=aspnetcore-6.0). You can find relevant code in:
* The `Startup` class: this is the initial configuration of the project
* The `OpenIdConnectOptionsInitializer` class sets up the OpenID Connect user login, using IClientAssertionsBuilder from the `Common` project
* The `IUserSessionDataStore` interface abstracts the persisting of user tokens
* The `AccessTokenUpdater` class updates access tokens when they have expired

HelseID is an Authorization Server that is based upon the protocols OAuth2 and OpenId Connect. Before we can use HelseID, we need to
have a *client* registered and configured in the HelseID Server Configuration. This sample code uses pre-existing clients which are already
present in the development environment for HelseID. The configuration for these clients are configured in the `Configuration` project located elsewhere
in this repo.

### User login

When you start the sample with `dotnet run` on the command line, you'll need to connect a web browser to the address that shows up in the console:
```
Now listening on: https://localhost:5151
Application started. Press Ctrl+C to shut down.
```
the default is `https://localhost:5151`, but you can change the port number in the file `ConfigurationValues.cs`in the `Configuration` folder in the hieararchy above this folder. If you want to change the port number, change the `ApiAccessWebServerPort`constant in that file.

Click "Login", and use the "Test IDP". Then log in as a well known test person. You should be redirected back to the application at `https://localhost:5151`.

### API Access

Next, we can get access to the [Sample API](./SampleApi/README.md) by running the API Access application provided here.

This is done by using the access token that we got from the authentication process as a bearer token when accessing the Sample API.

The access token is set as a ``Bearer`` token in the Authorization Header, after which we call the API and retrive the result.

### Requirements

The [.NET 7 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/7.0) is required to build the program.

If you need to use this sample to access an API, you will need to start the [Sample API project](../SampleAPI/README.md) in a separate terminal. Then, you can run this application. 

### Standard mode (user logon with API access)

To run the sample in standard mode (user logon with API access), enter the following on the command line inside this folder:
```
dotnet run
```

### User login only
To run the sample as a user login only application, start the application with the extra option: 
```
dotnet run --user-login-only
```

### Use of request objects (for use of a child organization number):
If you want to send an underenhet (child org. no) as part of the claim to the API, you will need to set this underenhet as part of a request object that is sent to HelseID. If
this underenhet is present in the client in HelseID, you will receive a claim of type `helseid://claims/client/claims/orgnr_child` as part of the access token. To do this, you can start the application with the extra option:

```
dotnet run --use-request-objects
```

### Use of resource indicators:
If you want to use the resource indicators sample, you will need to start the application with an extra option:

```
dotnet run --use-resource-indicators
```

### Use of token exchange:
If you want to use the token exchange sample, you will need to start the application with an extra option:

```
dotnet run --use-token-exchange
```
In addition to start the [Sample API project](../SampleAPI/README.md), you will also need to start the [Sample API for token exchange project](../SampleApiForTokenExchange/README.md). Look into that project folder for more information.


### To list all options:
```
dotnet run -- --help
```




