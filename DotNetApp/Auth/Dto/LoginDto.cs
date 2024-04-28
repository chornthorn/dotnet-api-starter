using System.ComponentModel.DataAnnotations;

namespace DotNetApp.Auth.Dto;

public class LoginDto
{
    /// <summary>
    /// Username of the user
    /// </summary>
    /// <example>admin</example>
    [Required]
    [MinLength(3, ErrorMessage = "Username must be at least 3 characters long")]
    public required string Username { get; set; }

    /// <summary>
    /// The password of the user
    /// </summary>
    /// <example>123456</example>
    [Required]
    [MinLength(6, ErrorMessage = "Password must be at least 6 characters long")]
    public required string Password { get; set; }
}