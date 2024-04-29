namespace DotNetApp.Core.attribute;


[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Interface, Inherited = true)]
public class InjectableAttribute(bool scoped = true) : Attribute
{
    public bool Scoped { get; } = scoped;
}