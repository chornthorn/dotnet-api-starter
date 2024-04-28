using DotNetApp.Core.Enum;

namespace DotNetApp.Core.attribute;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Interface, Inherited = true)]
public class RequiredJwtAuthAttribute(AuthType type = AuthType.AccessToken) : Attribute
{
    public AuthType Type { get; } = type;
}