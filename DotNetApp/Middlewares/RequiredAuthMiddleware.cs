using DotNetApp.Core.attribute;
using DotNetApp.Core.Enum;
using DotNetApp.Core.Security;
using DotNetApp.Core.Serivce;

namespace DotNetApp.Middlewares;

public class RequiredAuthMiddleware(
    RequestDelegate next,
    JwtService jwtService,
    JWKSManager jwksManager,
    RsaKeyProvider rsaKeyProvider,
    IConfiguration configuration)
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
        var requiredAuthAttribute = endpoint?.Metadata.GetMetadata<RequiredAuthAttribute>();

        if (requiredAuthAttribute != null && requiredAuthAttribute.Type == AuthType.AccessToken)
        {
            // Get the Authorization header
            var authHeader = context.Request.Headers["Authorization"].ToString();

            // Check if the header starts with "Bearer "
            if (authHeader.StartsWith("Bearer "))
            {
                // Remove the "Bearer " prefix
                var token = authHeader.Substring("Bearer ".Length);

                // Get the JWKS through the JWKSManager
                var jwks = await jwksManager.GetJWKSAsync();
                var jwksKid = configuration["keycloak:jwks:kid"];

                // Get the RSA key from the JWKS
                var rsaKey = jwks.Keys.FirstOrDefault(k => k.Kid == jwksKid);
                var rsa = rsaKeyProvider.CreateRsaFromJwk(rsaKey);


                // Validate the token
                if (!jwtService.ValidateToken(token: token, rsa: rsa))
                {
                    // If the token is invalid, set the response status code to 401 and return
                    throw new UnauthorizedAccessException("Unauthorized access. Invalid token.");
                }
                
                // retrieve the access token and then add it to the HttpContext for use in other parts of your application
                context.Items["AccessToken"] = token;
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