using System.ComponentModel.DataAnnotations;

namespace DotNetApp.Simples.Dto;

public class CreateSimpleDto
{
    /// <summary>
    /// Name of the simple
    /// </summary>
    /// <example>Simple 1</example>
    [Required]
    public required string Name { get; set; }
}