using DotNetApp.Auth.Dto;
using DotNetApp.Core;
using DotNetApp.Core.attribute;
using DotNetApp.Core.Enum;
using DotNetApp.Keycloak.Dto;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace DotNetApp.Auth;

[ApiController]
[Route("api/auth")]
[SwaggerTag("Authentication: Login, Register, User Info")]
public class AuthController(AuthService authService) : Controller
{
    [Public]
    [HttpPost("login")]
    [SwaggerOperation(
        Summary = "Login",
        Description = "Login",
        OperationId = "Auth.Login"
    )]
    public async Task<ActionResult<Response<string>>> Login([FromBody] string username)
    {
        return await authService.Login(username);
    }

    [Public]
    [HttpPost("register")]
    [SwaggerOperation(
        Summary = "Register",
        Description = "Register",
        OperationId = "Auth.Register"
    )]
    public async Task<ActionResult<Response<string>>> Register([FromBody] string username)
    {
        return await authService.Register(username);
    }

    [RequiredAuth(type: AuthType.AccessToken)]
    [HttpGet]
    [SwaggerOperation(
        Summary = "User Info",
        Description = "User Info",
        OperationId = "Auth.UserInfo"
    )]
    public async Task<ActionResult<Response<dynamic>>> UserInfo()
    {
        return await authService.UserInfo();
    }

    // keycloak login
    [Public]
    [HttpPost("keycloak-login")]
    [SwaggerOperation(
        Summary = "Keycloak Login",
        Description = "Keycloak Login",
        OperationId = "Auth.KeycloakLogin"
    )]
    public async Task<ActionResult<Response<LoginResDto>>> KeycloakLogin([FromBody] LoginReqDto dto)
    {
        return await authService.KeycloakLogin(dto);
    }

    // keycloak refresh token
    [Public]
    [HttpPost("keycloak-refresh-token")]
    [SwaggerOperation(
        Summary = "Keycloak Refresh Token",
        Description = "Keycloak Refresh Token",
        OperationId = "Auth.KeycloakRefreshToken"
    )]
    [SwaggerResponse(200, "Success", typeof(Response<LoginResDto>))]
    public async Task<ActionResult<Response<LoginResDto>>> KeycloakRefreshToken(
        [FromHeader] string refreshToken)
    {
        return await authService.KeycloakRefreshToken(refreshToken);
    }
    
    // keycloak user info
    [RequiredAuth(type: AuthType.AccessToken)]
    [HttpGet("keycloak-user-info")]
    [SwaggerOperation(
        Summary = "Keycloak User Info",
        Description = "Keycloak User Info",
        OperationId = "Auth.KeycloakUserInfo"
    )]
    public async Task<ActionResult<Response<KUserInfoDto>>> KeycloakUserInfo()
    {
        var accessToken = HttpContext.Items["AccessToken"].ToString();
        return await authService.KeycloakUserInfo(accessToken);
    }
    
    // keycloak logout
    [RequiredAuth(type: AuthType.AccessToken)]
    [HttpPost("keycloak-logout")]
    [SwaggerOperation(
        Summary = "Keycloak Logout",
        Description = "Keycloak Logout",
        OperationId = "Auth.KeycloakLogout"
    )]
    public async Task<ActionResult<Response<string>>> KeycloakLogout()
    {
        var accessToken = HttpContext.Items["AccessToken"].ToString();
        return await authService.KeycloakLogout(accessToken);
    }
}