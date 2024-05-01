using DotNetApp.Core.attribute;
using DotNetApp.Core.Context;
using Microsoft.EntityFrameworkCore;

namespace DotNetApp.Permissions;

[Repository]
public class PermissionsRepository(AppDbContext dbContext)
{
    public async Task<List<string>> GetPermissionsAsync()
    {
       var permissions = new List<string>
       {
           "View Users",
           "Add Users",
           "Edit Users",
           "Delete Users"
       };
       
       return permissions;
    }
}