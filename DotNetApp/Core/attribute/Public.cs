namespace DotNetApp.Core.attribute;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class PublicAttribute(bool value = true) : Attribute
{
    public bool Value { get; } = value;
}