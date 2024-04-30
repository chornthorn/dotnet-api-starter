using DotNetApp.Core.attribute;

namespace DotNetApp.Middlewares;

public class MockJwtAuthMiddleware
{
    public RequestDelegate next;
    
    public MockJwtAuthMiddleware(RequestDelegate next)
    {
        this.next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        if (context.Request.Path.Value == "/favicon.ico")
        {
            // Skip the rest of the pipeline
            return;
        }

        var endpoint = context.GetEndpoint();

        // Check if the endpoint is public and skip the policy enforcement
        var publicAttribute = endpoint?.Metadata.GetMetadata<PublicAttribute>();
        var isPublic = publicAttribute?.Value ?? false;

        // if (isPublic)
        // {
        //     await next(context);
        //     return;
        // }
        
        // add user data to the context
        context.Items["UserData"] = new UserData
        {
            Id = "1232452345234",
            Username = "test"
        };
        
        await next(context);
    }
}