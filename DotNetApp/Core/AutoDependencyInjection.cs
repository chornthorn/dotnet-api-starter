using System.Reflection;
using DotNetApp.Core.attribute;

namespace DotNetApp.Core;

public static class AutoDependencyInjection
{
    public static void InitializeAutoDependency(this IServiceCollection services)
    {
        // Get all the types in the current assembly
        var types = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(s => s.GetTypes())
            .Where(p => Attribute.IsDefined(p, typeof(InjectableAttribute)));

        // Check if any types were found
        var enumerable = types.ToList();
        if (enumerable.Count == 0)
        {
            throw new Exception("No types found with the [Injectable] attribute.");
        }

        // Find root dependencies (types that are not dependencies of any other types)
        var rootDependencies = enumerable
            .Where(t => !enumerable.Any(otherType => otherType.GetConstructors()
                .Any(c => c.GetParameters().Any(p => p.ParameterType == t))));

        // Register root dependencies
        var dependencies = rootDependencies.ToList();
        foreach (var type in dependencies)
        {
            // check if the type has a Scoped true [Injectable(Scoped: true)]
            var attribute = type.GetCustomAttribute<InjectableAttribute>();
            if (attribute is { Scoped: true })
            {
                services.AddScoped(type);
            }
            else
            {
                services.AddSingleton(type);
            }
        }

        // Register other dependencies
        var otherDependencies = enumerable.Except(dependencies);
        foreach (var type in otherDependencies)
        {
            // check if the type has a Scoped true [Injectable(Scoped: true)]
            var attribute = type.GetCustomAttribute<InjectableAttribute>();
            if (attribute is { Scoped: true })
            {
                services.AddScoped(type);
            }
            else
            {
                services.AddSingleton(type);
            }
        }
    }
}