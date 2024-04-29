namespace DotNetApp;

public static class DependencyInjection
{
    public static IServiceCollection AddCore(this IServiceCollection services)
    {
        services.AddHttpClient();
        return services;
    }

    public static IServiceCollection AddSecurity(this IServiceCollection services)
    {
        return services;
    }

    public static IServiceCollection AddFilters(this IServiceCollection services)
    {
        services.AddControllers(options =>
        {
            // add filters here
        });
        return services;
    }
}