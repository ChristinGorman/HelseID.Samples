using Microsoft.IdentityModel.Tokens;
using SecurityKey = HelseId.Samples.Common.Configuration.SecurityKey;

namespace HelseID.Samples.Configuration;

public static class ConfigurationValues
{
    // The URL for HelseID
    public const string StsUrl = "https://helseid-sts.test.nhn.no";

    // Audience and scopes for using the 'regular' sample API:
    public const string SampleApiNameAudience = "nhn:helseid-public-samplecode";

    public const string ClientCredentialsScopeForSampleApi = $"{SampleApiNameAudience}/client-credentials";

    public const string AuthorizationCodeScopeForSampleApi = $"{SampleApiNameAudience}/authorization-code";

    // Audience and scope for using the sample API that uses token exchange:
    public const string SampleTokenExchangeApiAudience = "nhn:helseid-public-samplecode-for-token-exchange";

    public const string TokenExchangeApiScope = $"{SampleTokenExchangeApiAudience}/token-exhange-endpoint";

    // Audiences and scopes for using the sample API for the resource indicator sample:
    public const string SampleApiForResourceIndicators1Audience = "nhn:helseid-public-sample-api-1";
    public const string SampleApiForResourceIndicators2Audience = "nhn:helseid-public-sample-api-2";

    public const string SampleApiForResourceIndicators1Scope = $"{SampleApiForResourceIndicators1Audience}/some-scope";
    public const string SampleApiForResourceIndicators2Scope = $"{SampleApiForResourceIndicators2Audience}/some-scope";

    // The scope that is needed for access to the clientinfo_endpoint on HelseID (https://helseid.atlassian.net/wiki/spaces/HELSEID/pages/492044292/Client+Info+Endpoint):
    private const string ClientInfoScope = "helseid://scopes/client/info";

    // HelseID security level claim
    public const string HelseIdSecurityLevelClaim = "helseid://claims/identity/security_level";

    // HelseID scopes defined at https://helseid.atlassian.net/wiki/spaces/HELSEID/pages/5603417/Scopes
    private const string GeneralHelseIdScopes = "helseid://scopes/identity/pid helseid://scopes/identity/pid_pseudonym helseid://scopes/identity/assurance_level helseid://scopes/hpr/hpr_number helseid://scopes/identity/network helseid://scopes/identity/security_level";

    // Port numbers for the different sample APIs
    public const int SampleApiPort = 5081;

    public const int SampleApiForResourceIndicators1Port = 5082;

    public const int SampleApiForResourceIndicators2Port = 5083;

    public const int SampleApiForTokenExchangePort = 5092;

    // Port number for the API Access project
    public const int ApiAccessWebServerPort = 5151;

    // URLS and resource parameters (url fragments) for the use of the sample APIs for the API access project
    public const string AuthCodeClientResource = "user-login-clients/greetings";
    public const string TokenExchangeResource = "token-exchange-clients/greetings";
    public const string ResourceIndicatorsResource1 = "resource-indicator-client-1/greetings";
    public const string ResourceIndicatorsResource2 = "resource-indicator-client-2/greetings";

    public static string SampleApiUrl = $"https://localhost:{SampleApiPort}/{AuthCodeClientResource}";
    public static string SampleApiUrlForTokenExchange = $"https://localhost:{SampleApiForTokenExchangePort}/{TokenExchangeResource}";
    public static string SampleApiUrlForResourceIndicators1 = $"https://localhost:{SampleApiForResourceIndicators1Port}/{ResourceIndicatorsResource1}";
    public static string SampleApiUrlForResourceIndicators2 = $"https://localhost:{SampleApiForResourceIndicators2Port}/{ResourceIndicatorsResource2}";

    // URLS and resource parameter (url fragment) for the use of the sample API for the client credentials project
    public const string SampleApiMachineClientResource = "machine-clients/greetings";

    public static string SampleApiUrlForM2M = $"https://localhost:{SampleApiPort}/{SampleApiMachineClientResource}";

    // If used, the child organization number (underenhet) must match a number in the client's whitelist as it's held by HelseID:
    public const string ClientCredentialsWithChildOrganizationNumber = "999977776";
    public const string ApiAccessWithRequestObjectChildOrganizationNumber = "999977776";

    // ----------------------------------------------------------------------------------------------------------------------
    // These private key JWKs match the public keys in HelseID that are attached to the corresponding client configurations:
    // ----------------------------------------------------------------------------------------------------------------------
    // In a production scenario, a private key MUST be secured inside the client, and NOT be set in source code
    // In this case, the clients also share a private key. In a production environment, all clients must have separate keys
    // ----------------------------------------------------------------------------------------------------------------------
    private const string GeneralPrivateRsaKey = "{ 'p': '1JDtA9RzEs-dgZ7YDOZPX4VJLofseq9cs7rTvxF9I6QXo3_0-FIkymdiitIcLrfXtRcmJ8bIDzhHYYUkt_5cYSdCjg90EsbLRyjz7xl4wXgCJsEga-shhjxMqiZ7JS5lMd2FkuHw9fk6iDlokmn6zIMDFgSwCy-avN4Wl8k0tS8', 'kty': 'RSA', 'q': 'nQd92kOJqtjgWy6DEeOCAsW18qLYEiXXDYFpWnxNBK9Bx5ao01UmfSGyjeCyrmYrxGdUsyXQRirUlUq5foXhbC6noiVLv2763p2vwdbQdy6UPj5rzjPhmaKBV3MXi-VKB7Hdf6vR6AXk5dBIBTPlmjJor-blngu3QKoIpzisLDM', 'd': 'NnL8DUu6Ci0BCJXN88RyQ-Og_j4tF3LkzIFg45ehkJRcxSIFU53hrewKqdVkkjFCl898CT_5AqItzjJeW6BGW5nVOVOACu_FNcCFM9_ZevXM5VtrwS5zFmQep19JZ5uFOPcBGjLOU5vd0FoBckZ2YtwvP5p8dHjL3tA0R2nvkSsOBQYCcrPvFwYLlMSxEfbvKZWUAIX3wtKOmfOw3daa5fYkpUxBXz2XcMYhXZE87vUA0qG_1d6K0r51DEayuej9D11lcIxCWXWi1LAT7FFjikt8nKxeRIZEieViPEjxw8gSWKLGMMy2FZQgLLvDuHmTzuEDPgZVBbCElkl7l8dMYQ', 'e': 'AQAB', 'use': 'sig', 'qi': '09EacJNthPVKNoea8Nj5PC37iilrc2mlVQtrXobCAkHcByVR7xPZT1cZZ3NSiMpSQu2y4tr_LA62xmnSU3zVgcEi9CfI8h2nGN82wv8SVxtUK9-RcqAohJj0y4UtnhA9atcTfZvlI5RLMP7mdLnkgzZe9Oq7Jr_OMD4IKZhG8-E', 'dp': 'iBXkd5A6v69FUifEf7Wu2SN2r6B7iCveuH4CdA-ZQwkZzSXtSlEklqRLlT5gppQyOBCC7_I2QHAyWr-nu1fQAq7k0Bgaoq68k2knikqPYaUYE4GO5ShahRrzpfcO3cXvKVZ93oRiBMezbmT6isnos6eogR8tKWwnr4SriC9bXCc', 'alg': 'RS512', 'dq': 'm2g6qbSFnswc3qDdnuqmVNAPDh8T8IH6n6cf-Sljn-tDEqCMXPq8qMKcz8U9kVQUpMAPF22o_oiM82OMySb-ve4-gT6gBMl1BrTQqOpMTmeO1zs3vk-iSkaF82I4P3-hEJR7Pktx5ktPChJj9KIz7bNN4CiHvy6hIiIlhjmUS_k', 'n': 'gmMZ0dOeUyEbEQ0Bz4gGqcYgMfreJ1yIMD_h0HyRjNB0-e1jzb4yjBBkx1pOpPvt02trdyt_nOCmR7DLrHmLrDCmAbpYIytUPNEuz6GJkT31oL3vDmNqrkawQwe3B04FIWohiTQWgnPaZiTViRdajxpJJW6juPVzr75TlWwyimT2bDq-5TxwiLxyRJDUUWnTvjUPkFVHGMwNFQxV9SCrjHSueCF8vQ959Peh-Yxvtvz2T29HgHKf7oh37DCEy-PrWLTgykeEvNhyWclDM4jm5NaqOCE-sbmmRR4wnCWksvGod7aS7IaKzg2_nNihrxAIzIOqEuLXXaUmYPeHKDgsXQ' }";
    public static readonly SecurityKey ClientCredentialsSampleRsaPrivateKeyJwk = new(GeneralPrivateRsaKey, SecurityAlgorithms.RsaSha512);
    public static readonly SecurityKey ClientCredentialsWithChildOrgNumberSamplePrivateKeyJwk = new(GeneralPrivateRsaKey, SecurityAlgorithms.RsaSha512);
    public static readonly SecurityKey ApiAccessSampleRsaPrivateKeyJwk = new(GeneralPrivateRsaKey, SecurityAlgorithms.RsaSha512);
    public static readonly SecurityKey TokenExchangeSubjectRsaPrivateKeyJwk = new(GeneralPrivateRsaKey, SecurityAlgorithms.RsaSha512);
    public static readonly SecurityKey TokenExchangActorRsaPrivateKeyJwk = new(GeneralPrivateRsaKey, SecurityAlgorithms.RsaSha512);
    public static readonly SecurityKey ApiAccessWithRequestObjectSampleRsaPrivateKeyJwk = new(GeneralPrivateRsaKey, SecurityAlgorithms.RsaSha512);
    public static readonly SecurityKey ApiAccessResourceIndicatorRsaPrivateKeyJwk = new(GeneralPrivateRsaKey, SecurityAlgorithms.RsaSha512);
    // We can also use an elliptic curve algorithm if we wish (this has nothing to do with the actual client)
    private const string EllipticCurvePrivateKey = "{ 'kty': 'EC', 'd': 'BG3mkAdvG0rWnahVtIaCfj2yOH-m0FZbbEOlwXOEIeiBRwYFQEPAII_dVSYNZX-l', 'use': 'sig', 'crv': 'P-384', 'x': 'khAS2R2atO0i7Y7O257HsDeXkp7Rt_D-4HWv5Q3kJBuWw43I9NcTCmGEQZjoP5EL', 'y': '3NxlAKU0SNfnKgvse4NhUz-Bqy7yONtDBxWBxvw1ZtQ82P6jdBFIPrO5u8UMPb7Y', 'alg': 'ES384'}";
    public static readonly SecurityKey UserAuthenticationPrivateKeyJwk = new(EllipticCurvePrivateKey, SecurityAlgorithms.EcdsaSha384);

    // -----------------------------------------------------------------------------------------------------------------
    // Client IDs:
    // -----------------------------------------------------------------------------------------------------------------
    // In HelseID, these are normally set as GUIDS, here we have named them for better readability 
    // -----------------------------------------------------------------------------------------------------------------
    public const string ClientCredentialsSampleClientId = "helseid-sample-client-credentials";
    public const string ClientCredentialsWithChildOrgNumberSampleClientId = "helseid-sample-client-credentials-with-underenhet";
    public const string ApiAccessSampleClientId = "helseid-sample-api-access";
    public const string TokenExchangeSubjectClientId = "helseid-sample-token-exchange-subject-client";
    public const string TokenExchangeActorClientId = "helseid-sample-token-exchange-actor-client";
    public const string ApiAccessSampleClientIdWithRequestObject = "helseid-sample-request-objects-console";
    public const string ApiAccessResourceIndicatorClientId = "helseid-sample-resource-indicators";
    public const string UserAuthenticationClientId = "helseid-sample-client-authentication";

    // -----------------------------------------------------------------------------------------------------------------
    // Client scopes:
    // -----------------------------------------------------------------------------------------------------------------

    // Sets both the client credential scope (for claims that the sample API needs) and the client info scope for use against the client info endpoint:
    public const string ClientCredentialsSampleScope = $"{ClientCredentialsScopeForSampleApi} {ClientInfoScope}";
    public const string ApiAccessSampleScope = $"openid profile offline_access {AuthorizationCodeScopeForSampleApi} {GeneralHelseIdScopes}";
    public const string TokenExchangeSubjectClientScope = $"openid profile offline_access {TokenExchangeApiScope} {GeneralHelseIdScopes}";
    public const string TokenExchangeActorClientScope = $"{ClientCredentialsScopeForSampleApi}";
    public const string ApiAccessWithRequestObjectSampleScope = $"openid profile offline_access {AuthorizationCodeScopeForSampleApi} {GeneralHelseIdScopes}";
    public const string ApiAccessResourceIndicatorClientScope = $"openid profile offline_access {SampleApiForResourceIndicators1Scope} {SampleApiForResourceIndicators2Scope} {GeneralHelseIdScopes}";
    // No offline_access, this is for user login only:
    public const string UserAuthenticationClientScope = $"openid profile helseid://scopes/identity/pid helseid://scopes/identity/security_level";
}
