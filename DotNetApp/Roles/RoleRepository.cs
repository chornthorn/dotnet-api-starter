using DotNetApp.Core.attribute;
using DotNetApp.Core.Context;

namespace DotNetApp.Role;

[Injectable]
public class RoleRepository(AppDbContext dbContext)
{
    public async Task<Entities.Role> GetRoles()
    {
        var roles = await dbContext.Roles;
          return roles;
    }
}