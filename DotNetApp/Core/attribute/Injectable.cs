namespace DotNetApp.Core.attribute;

/// <summary>
/// Specifies that a class or interface is injectable and can be registered with a dependency injection container.
/// </summary>
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface)]
public class InjectableAttribute : Attribute
{
    /// <summary>
    /// Initializes a new instance of the <see cref="InjectableAttribute"/> class with the specified service lifetime.
    /// </summary>
    /// <param name="lifetime">The service lifetime to be used when registering the class or interface.</param>
    public InjectableAttribute(ServiceLifetime lifetime = ServiceLifetime.Scoped)
    {
        Lifetime = lifetime;
    }

    /// <summary>
    /// Gets or sets the service lifetime to be used when registering the class or interface.
    /// </summary>
    public ServiceLifetime Lifetime { get; set; }
}