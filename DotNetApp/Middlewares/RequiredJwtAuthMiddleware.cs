using DotNetApp.Core.attribute;
using DotNetApp.Core.Enum;
using DotNetApp.Core.Serivce;

namespace DotNetApp.Middlewares;

public class RequiredJwtAuthMiddleware(RequestDelegate next, JwtService jwtService)
{
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

        if (isPublic)
        {
            await next(context);
            return;
        }

        // Check if the endpoint has a RequiredAuth attribute
        var requiredAuthAttribute = endpoint?.Metadata.GetMetadata<RequiredJwtAuthAttribute>();

        if (requiredAuthAttribute != null && requiredAuthAttribute.Type == AuthType.AccessToken)
        {
            // Get the Authorization header
            var authHeader = context.Request.Headers["Authorization"].ToString();

            // Check if the header starts with "Bearer "
            if (authHeader.StartsWith("Bearer "))
            {
                // Remove the "Bearer " prefix
                var token = authHeader.Substring("Bearer ".Length);

                // Validate the token
                if (!jwtService.ValidateToken(token))
                {
                    // If the token is invalid, set the response status code to 401 and return
                    throw new UnauthorizedAccessException("Unauthorized access. Invalid token.");
                }
            }
            else
            {
                // If the header does not start with "Bearer ", set the response status code to 401 and return
                throw new UnauthorizedAccessException("Unauthorized access. Missing Bearer token.");
            }
        }

        // Call the next middleware in the pipeline
        await next(context);
    }
}