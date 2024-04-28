using DotNetApp.Core.Enum;

namespace DotNetApp.Core.attribute;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Interface, Inherited = true)]
public class PolicyAttribute(string resource, Scope scope) : Attribute
{
    public string Resource { get; } = resource;
    public Scope? Scope { get; } = scope;
}