namespace DotNetApp.Users.Dto;

public class UpdateUserDto
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Role { get; set; }
    public string Avatar { get; set; }
}