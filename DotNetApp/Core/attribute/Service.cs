namespace DotNetApp.Core.attribute;

/// <summary>
/// Represents an attribute that is used to mark a class or interface as a service.
/// </summary>
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface)]
public class ServiceAttribute : Attribute
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ServiceAttribute"/> class with the specified service lifetime.
    /// </summary>
    /// <param name="lifetime">The lifetime of the service.</param>
    public ServiceAttribute(ServiceLifetime lifetime = ServiceLifetime.Scoped)
    {
        Lifetime = lifetime;
    }

    /// <summary>
    /// Gets or sets the lifetime of the service.
    /// </summary>
    public ServiceLifetime Lifetime { get; set; }
}