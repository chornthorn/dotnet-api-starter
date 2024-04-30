using DotNetApp.Core.Enum;

namespace DotNetApp.Core.attribute;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true)]
public class RequiredAuthAttribute(AuthType type = AuthType.AccessToken) : Attribute
{
    public AuthType Type { get; } = type;
}