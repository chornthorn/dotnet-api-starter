namespace DotNetApp.Middlewares;

public static class ApplicationMiddleware
{
    public static IApplicationBuilder AddMiddlewares(this IApplicationBuilder app)
    {
        app.UseMiddleware<ExceptionHandlerMiddleware>();
        // app.UseMiddleware<PolicyEnforcementMiddleware>();
        app.UseMiddleware<RequiredAuthMiddleware>();
        app.UseMiddleware<AccessTokenRetrievalMiddleware>();
        return app;
    }
}