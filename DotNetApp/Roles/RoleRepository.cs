using DotNetApp.Core.attribute;
using DotNetApp.Core.Context;
using DotNetApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace DotNetApp.Roles;

[Injectable]
public class RoleRepository(AppDbContext dbContext)
{
    public async Task<List<Role>> GetRoles()
    {
        try {
            var roles = await dbContext.Roles.ToListAsync();
            return roles;
        } catch (Exception e) {
            throw new Exception(e.Message);
        }
    }
    
    public async Task<Role> GetRole(int id)
    {
        try {
            var role = await dbContext.Roles.FirstOrDefaultAsync(r => r.Id == id);
            return role;
        } catch (Exception e) {
            throw new Exception(e.Message);
        }
    }
    
    public async Task<Role> CreateRole(Role role)
    {
        try {
            await dbContext.Roles.AddAsync(role);
            await dbContext.SaveChangesAsync();
            return role;
        } catch (Exception e) {
            throw new Exception(e.Message);
        }
    }
    
    public async Task<Role> UpdateRole(int id, Role role)
    {
        try {
            var existingRole = await dbContext.Roles.FirstOrDefaultAsync(r => r.Id == id);
            if (existingRole == null) {
                throw new Exception("Role not found");
            }
            existingRole.Name = role.Name;
            await dbContext.SaveChangesAsync();
            return existingRole;
        } catch (Exception e) {
            throw new Exception(e.Message);
        }
    }
    
    public async Task<Role> DeleteRole(int id)
    {
        try {
            var role = await dbContext.Roles.FirstOrDefaultAsync(r => r.Id == id);
            if (role == null) {
                throw new Exception("Role not found");
            }
            dbContext.Roles.Remove(role);
            await dbContext.SaveChangesAsync();
            return role;
        } catch (Exception e) {
            throw new Exception(e.Message);
        }
    }
}