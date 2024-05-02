namespace DotNetApp.Core.attribute;

/// <summary>
/// Represents an attribute that can be applied to classes or interfaces to indicate that they are repositories.
/// </summary>
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface)]
public class RepositoryAttribute : Attribute
{
    /// <summary>
    /// Initializes a new instance of the <see cref="RepositoryAttribute"/> class with the specified service lifetime.
    /// </summary>
    /// <param name="lifetime">The service lifetime to be used for the repository.</param>
    public RepositoryAttribute(ServiceLifetime lifetime = ServiceLifetime.Scoped)
    {
        Lifetime = lifetime;
    }

    /// <summary>
    /// Gets or sets the service lifetime for the repository.
    /// </summary>
    public ServiceLifetime Lifetime { get; set; }
}