namespace DotNetApp.Middlewares;

public class AccessTokenRetrievalMiddleware(RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext context)
    {
        string accessToken = context.Request.Headers["Authorization"].ToString().Split(' ').Last();

        // Now you have the access token, you can use it as needed.
        // For example, you can add it to the HttpContext for use in other parts of your application:
        context.Items["AccessToken"] = accessToken;

        // Call the next middleware in the pipeline
        await next(context);
    }
}