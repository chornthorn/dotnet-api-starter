namespace DotNetApp.Keycloak.Dto;

public class LoginReqDto
{
    public required string Username { get; set; }
    public required string Password { get; set; }
}