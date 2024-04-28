using DotNetApp.Auth.Dto;
using DotNetApp.Core;
using DotNetApp.Core.attribute;
using DotNetApp.Core.Serivce;
using DotNetApp.Keycloak;
using DotNetApp.Keycloak.Dto;
using Microsoft.AspNetCore.Mvc;

namespace DotNetApp.Auth;

[Injectable]
public class AuthService(JwtService jwtService, KeycloakService keycloakService)
{
    public async Task<ActionResult<Response<string>>> Login([FromBody] string username)
    {
        try
        {
            var token = jwtService.GenerateToken(username);
            return new Response<string> { Success = true, Data = token };
        }
        catch
        {
            return new Response<string> { Success = false, Message = "Failed to generate token" };
        }
    }

    public async Task<ActionResult<Response<string>>> Register(string username)
    {
        try
        {
            var token = jwtService.GenerateToken(username);
            return new Response<string> { Success = true, Data = token };
        }
        catch
        {
            return new Response<string> { Success = false, Message = "Failed to generate token" };
        }
    }

    public async Task<ActionResult<Response<dynamic>>> UserInfo()
    {
        try
        {
            var user = new { Username = "admin" };
            return new Response<dynamic> { Success = true, Data = user };
        }
        catch
        {
            return new Response<dynamic> { Success = false, Message = "Failed to get user info" };
        }
    }

    public async Task<ActionResult<Response<LoginResDto>>> KeycloakLogin(LoginReqDto loginDto)
    {
        try
        {
            var loginResDto = await keycloakService.Login(new LoginReqDto
            {
                Username = loginDto.Username,
                Password = loginDto.Password
            });

            return new Response<LoginResDto> { Success = true, Data = loginResDto };
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new Response<LoginResDto> { Success = false, Message = "Failed to generate token" };
        }
    }

    public async Task<ActionResult<Response<LoginResDto>>> KeycloakRefreshToken(string refreshToken)
    {
        try
        {
            var loginResDto = await keycloakService.RefreshToken(refreshToken);
            return new Response<LoginResDto> { Success = true, Data = loginResDto };
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new Response<LoginResDto> { Success = false, Message = "Failed to generate token" };
        }
    }

    public async Task<ActionResult<Response<KUserInfoDto>>> KeycloakUserInfo(string accessToken)
    {
        try
        {
            var userInfo = await keycloakService.UserInfo(accessToken);
            return new Response<KUserInfoDto> { Success = true, Data = userInfo };
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new Response<KUserInfoDto> { Success = false, Message = "Failed to get user info" };
        }
    }

    public async Task<ActionResult<Response<string>>> KeycloakLogout(string accessToken)
    {
        try
        {
            await keycloakService.Logout(accessToken);
            return new Response<string> { Success = true, Data = "Logged out" };
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new Response<string> { Success = false, Message = "Failed to logout" };
        }
    }
}