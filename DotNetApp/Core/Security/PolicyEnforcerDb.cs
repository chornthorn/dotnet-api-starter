using DotNetApp.Core.Context;
using DotNetApp.Core.Enum;

namespace DotNetApp.Core.Security;

public class PolicyEnforcerDb(AppDbContext dbContext) : IPolicyEnforcer
{
    public Task<bool> EnforcePolicy(string resource, Scope scope, HttpContext context)
    {
        Console.WriteLine($"Enforcing policy for resource: {resource} and scope: {scope.AsString()}");
        
        // Check if the user has the required permission from userRole
        throw new NotImplementedException();
        
    }
}