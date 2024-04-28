namespace DotNetApp.Auth.Dto;

public class KUserInfoDto
{
    public string Id { get; set; } = string.Empty;
    public string Username { get; set; }
    public string Email { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string GivenName { get; set; } = string.Empty;
    public string FamilyName { get; set; } = string.Empty;
    public bool EmailVerified { get; set; } = false;
}