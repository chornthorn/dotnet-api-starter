using System.ComponentModel.DataAnnotations;

namespace DotNetApp.Auth.Dto;

public class LoginReqDto
{
    /// <summary>
    /// Username of the user
    /// </summary>
    /// <example>thorn</example>
    [Required]
    public required string Username { get; set; }
    
    /// <summary>
    /// Password of the user
    /// </summary>
    /// <example>123456</example>
    [Required]
    public required string Password { get; set; }
}