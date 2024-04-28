using System.ComponentModel.DataAnnotations;

namespace DotNetApp.Auth.Dto;

public class RegisterReqDto
{
    [Required]
    [MinLength(3, ErrorMessage = "Username must be at least 3 characters")]
    public string Username { get; set; }

    [Required]
    [MinLength(6, ErrorMessage = "Password must be at least 6 characters")]
    public string Password { get; set; }

    public string Email { get; set; } = string.Empty;
}