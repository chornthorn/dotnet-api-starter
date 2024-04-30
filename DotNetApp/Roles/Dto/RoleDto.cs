namespace DotNetApp.Roles.Dto;

public class RoleDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
}