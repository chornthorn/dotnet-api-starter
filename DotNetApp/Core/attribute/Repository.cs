namespace DotNetApp.Core.attribute;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface)]
public class RepositoryAttribute(ServiceLifetime lifetime = ServiceLifetime.Scoped) : Attribute
{
    public ServiceLifetime Lifetime { get; set; } = lifetime;
}