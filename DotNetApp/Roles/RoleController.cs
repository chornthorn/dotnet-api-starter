using Microsoft.AspNetCore.Mvc;

namespace DotNetApp.Roles;

[ApiController]
[Route("api/roles")]
public class RoleController(RoleService roleService): Controller
{
    [HttpGet]
    public async Task<ActionResult<Entities.Role>> GetRoles() {
        return await roleService.GetRoles();
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<Entities.Role>> GetRole(int id) {
        return await roleService.GetRole(id);
    }
    
    [HttpPost]
    public async Task<ActionResult<Entities.Role>> CreateRole(Entities.Role role) {
        return await roleService.CreateRole(role);
    }
    
    [HttpPut("{id}")]
    public async Task<ActionResult<Entities.Role>> UpdateRole(int id, Entities.Role role) {
        return await roleService.UpdateRole(id, role);
    }
    
    [HttpDelete("{id}")]
    public async Task<ActionResult<Entities.Role>> DeleteRole(int id) {
        return await roleService.DeleteRole(id);
    }
}