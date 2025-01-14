using System.Security.Claims;
using HelseId.SampleApi.Configuration;
using HelseId.SampleApi.Interfaces;
using HelseId.Samples.Common.Models;

namespace HelseId.SampleAPI.Controllers;

public class ApiResponseCreator : IApiResponseCreator
{
    private readonly Settings _settings;

    public ApiResponseCreator(Settings settings)
    {
        _settings = settings;
    }

    public ApiResponse CreateApiResponse(List<Claim> claims, string apiName)
    {
        return new ApiResponse
        {
            Greeting = CreateGreeting(claims, apiName),
            OrganizationNumber = claims.SingleOrDefault(c => c.Type == "helseid://claims/client/claims/orgnr_parent")?.Value,
            ChildOrganizationNumber = claims.SingleOrDefault(c => c.Type == "helseid://claims/client/claims/orgnr_child")?.Value,
        };
    }

    private string CreateGreeting(IEnumerable<Claim> claims, string apiName)
    {
        var name = claims.SingleOrDefault(c => c.Type == "name")?.Value;
        
        var greeting = name == null ?
            $"Hello from the {apiName}!" :
            $"Hello from the {apiName}, {name}!";

        return $"{greeting} The local time is {DateTime.Now:HH:mm:ss}.";
    }
}