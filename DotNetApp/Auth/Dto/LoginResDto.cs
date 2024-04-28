namespace DotNetApp.Keycloak.Dto;

public class LoginResDto
{
    public string AccessToken { get; set; } = string.Empty;
    public string RefreshToken { get; set; } = string.Empty;
    public string TokenType { get; set; } = string.Empty;
    public int ExpiresIn { get; set; } = 0;

    // empty data static
    public static LoginResDto IsEmpty => new LoginResDto();
}