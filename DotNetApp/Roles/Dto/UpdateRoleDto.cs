namespace DotNetApp.Roles.Dto;

public class UpdateRoleDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; } = string.Empty;
}