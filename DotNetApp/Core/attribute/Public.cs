namespace DotNetApp.Core.attribute;

/// <summary>
/// Represents a custom attribute that can be applied to classes or methods to indicate their public accessibility.
/// </summary>
/// <param name="value">The value indicating whether the class or method is public. Default is true.</param>
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class PublicAttribute(bool value = true) : Attribute
{
    public bool Value { get; } = value;
}