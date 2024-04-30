using DotNetApp.Core.Context;
using Microsoft.EntityFrameworkCore;

namespace DotNetApp;

public static class DependencyInjection
{
    private static IServiceCollection ApplyDbConnection(this IServiceCollection services)
    {
        var dbConnection = services.BuildServiceProvider().GetService<IConfiguration>()
            ?.GetConnectionString("DefaultConnection");
        var serverVersion = new MySqlServerVersion(new Version(8, 0, 2));
        services.AddDbContext<AppDbContext>(options => options.UseMySql(dbConnection, serverVersion: serverVersion));
        return services;
    }

    // Initialize database
    public static async Task InitializeDatabase(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var services = scope.ServiceProvider;
        var context = services.GetRequiredService<AppDbContext>();
        await context.Database.MigrateAsync();
    }

    public static IServiceCollection AddCore(this IServiceCollection services)
    {
        services.AddHttpClient();
        services.AddHttpContextAccessor();
        return services;
    }

    public static IServiceCollection AddBindings(this IServiceCollection services)
    {
        return services;
    }

    public static IServiceCollection ManualDependency(this IServiceCollection services)
    {
        // Apply database connection
        services.ApplyDbConnection();

        // Add injectables here:

        return services;
    }
}