namespace DotNetApp.Roles.Dto;

public class CreateRoleDto
{
    public string Name { get; set; }
    public string Description { get; set; } = string.Empty;
}