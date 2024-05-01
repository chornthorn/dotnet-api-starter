using System.Reflection;
using DotNetApp.Core.attribute;

namespace DotNetApp.Core;

public static class AutoDependencyInjection
{
    private static void InitializeAutoDependencies<TAttribute>(this IServiceCollection services)
        where TAttribute : Attribute
    {
        // Get all the types in the current assembly
        var types = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(s => s.GetTypes())
            .Where(p => Attribute.IsDefined(p, typeof(TAttribute)));

        // Check if any types were found
        var enumerable = types.ToList();
        if (enumerable.Count == 0)
        {
            throw new Exception($"No types found with the [{typeof(TAttribute).Name}] attribute.");
        }

        // Find root dependencies (types that are not dependencies of any other types)
        var rootDependencies = enumerable
            .Where(t => !enumerable.Any(otherType => otherType.GetConstructors()
                .Any(c => c.GetParameters().Any(p => p.ParameterType == t))));

        // Register root dependencies
        var dependencies = rootDependencies.ToList();
        foreach (var type in dependencies)
        {
            // check if the type has the specified attribute
            var attribute = type.GetCustomAttribute<TAttribute>();

            // Extract the Lifetime property if it exists
            var lifetimeProperty = typeof(TAttribute).GetProperty("Lifetime");
            var lifetime = lifetimeProperty != null
                ? (ServiceLifetime)lifetimeProperty.GetValue(attribute)
                : ServiceLifetime.Scoped;

            // using switch case for ServiceLifetime
            switch (lifetime)
            {
                case ServiceLifetime.Singleton:
                    services.AddSingleton(type);
                    break;
                case ServiceLifetime.Scoped:
                    services.AddScoped(type);
                    break;
                case ServiceLifetime.Transient:
                    services.AddTransient(type);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        // Register other dependencies
        var otherDependencies = enumerable.Except(dependencies);
        foreach (var type in otherDependencies)
        {
            // check if the type has the specified attribute
            var attribute = type.GetCustomAttribute<TAttribute>();

            // Extract the Lifetime property if it exists
            var lifetimeProperty = typeof(TAttribute).GetProperty("Lifetime");
            var lifetime = lifetimeProperty != null
                ? (ServiceLifetime)lifetimeProperty.GetValue(attribute)
                : ServiceLifetime.Scoped;

            // using switch case for ServiceLifetime
            switch (lifetime)
            {
                case ServiceLifetime.Singleton:
                    services.AddSingleton(type);
                    break;
                case ServiceLifetime.Scoped:
                    services.AddScoped(type);
                    break;
                case ServiceLifetime.Transient:
                    services.AddTransient(type);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }

    // register
    public static void RegisterDependencyInitialization(this IServiceCollection services)
    {
        services.InitializeAutoDependencies<InjectableAttribute>();
        services.InitializeAutoDependencies<ServiceAttribute>();
        services.InitializeAutoDependencies<RepositoryAttribute>();
    }
}