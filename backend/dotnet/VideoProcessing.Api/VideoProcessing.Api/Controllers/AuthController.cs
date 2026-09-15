using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace VideoProcessingService.Controllers;


[ApiController]
[Route("auth")]
public class AuthController : ControllerBase
{
    private readonly IConfiguration _configuration;

    public AuthController(IConfiguration configuration) 
    {
        _configuration = configuration;
    }

    [HttpGet("login")]
    public IActionResult Login()
    {
        return Challenge(new AuthenticationProperties
        {
            RedirectUri = _configuration["Frontend:BaseUrl"]
        },
            OpenIdConnectDefaults.AuthenticationScheme);
    }

    [Authorize]
    [HttpGet("me")]
    public IActionResult Me()
    {
        var email = User.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress")?.Value;
        var role = User.FindFirst("cognito:groups")?.Value;

        return Ok(new
        {
            authenticated = true,
            email,
            role
        });
    }

    [HttpGet("logout")]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(
            CookieAuthenticationDefaults.AuthenticationScheme);

        var cognitoDomain =
            "https://us-east-1v3nnw3xpi.auth.us-east-1.amazoncognito.com";

        var clientId =
            _configuration["OpenIDConnectSettings:ClientId"];

        var logoutUri =
            _configuration["Frontend:BaseUrl"];

        var logoutUrl =
            $"{cognitoDomain}/logout" +
            $"?client_id={Uri.EscapeDataString(clientId!)}" +
            $"&logout_uri={Uri.EscapeDataString(logoutUri!)}";

        return Redirect(logoutUrl);
    }
}