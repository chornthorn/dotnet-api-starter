using DotNetApp.Core.attribute;
using Microsoft.AspNetCore.Mvc;

namespace DotNetApp.Role;

[Injectable]
public class RoleService(RoleRepository roleRepository)
{
    public async Task<ActionResult<Role>> GetRoles()
    {
        throw new NotImplementedException();
    }
}