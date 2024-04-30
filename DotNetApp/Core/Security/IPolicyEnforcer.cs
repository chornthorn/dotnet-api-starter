using DotNetApp.Core.Enum;

namespace DotNetApp.Core.Security;

public interface IPolicyEnforcer
{
    Task<bool> EnforcePolicy(string resource, Scope scope, HttpContext context);
}