using HelseId.SampleApi.Interfaces;
using HelseId.Samples.Common.Models;
using HelseID.Samples.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HelseId.SampleAPI.Controllers;

[ApiController]
[Authorize(Policy=Startup.AuthCodePolicy, AuthenticationSchemes = Startup.TokenAuthenticationScheme)] // Authentication is needed to access the API
public class AuthCodeController: ControllerBase
{
    private readonly IApiResponseCreator _responseCreator;
    public AuthCodeController(IApiResponseCreator responseCreator)
    {
        _responseCreator = responseCreator;
    }

    [HttpGet]
    [Route(ConfigurationValues.AuthCodeClientResource)]
    public ActionResult<ApiResponse> GetDefault()
    {
        return CreateResult("Sample API");
    }
    
    [HttpGet]
    [Route(ConfigurationValues.ResourceIndicatorsResource1)]
    public ActionResult<ApiResponse> GetForIndicator1()
    {
        return CreateResult("Sample API (indicator 1)");
    }
    
    [HttpGet]
    [Route(ConfigurationValues.ResourceIndicatorsResource2)]
    public ActionResult<ApiResponse> GetForIndicator2()
    {
        return CreateResult("Sample API (indicator 2)");
    }

    private ActionResult<ApiResponse> CreateResult(string apiName)
    {
        // The claims of the logged in user:
        var claims = User.Claims.ToList();

        var apiResponse = _responseCreator.CreateApiResponse(claims, apiName);

        return new JsonResult(apiResponse);
    }
}