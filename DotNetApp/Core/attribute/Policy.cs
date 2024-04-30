using DotNetApp.Core.Enum;

namespace DotNetApp.Core.attribute;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class AuthPolicyAttribute(string resource, Scope scope) : Attribute
{
    public string Resource { get; } = resource;
    public Scope? Scope { get; } = scope;
}