using DotNetApp.Core.attribute;
using DotNetApp.Core.Enum;
using DotNetApp.Core.Exceptions;
using DotNetApp.Core.Security;

namespace DotNetApp.Middlewares;

public class PolicyEnforcementMiddleware(RequestDelegate next, HttpClient httpClient, IConfiguration configuration)
{
    private readonly PolicyEnforcer _policyEnforcer = new(httpClient, configuration);

    public async Task InvokeAsync(HttpContext context)
    {
        if (context.Request.Path.Value == "/favicon.ico")
        {
            // Skip the rest of the pipeline
            return;
        }

        // Get the endpoint information
        var endpoint = context.GetEndpoint();

        // Check if the endpoint is public and skip the policy enforcement
        var publicAttribute = endpoint?.Metadata.GetMetadata<PublicAttribute>();
        var isPublic = publicAttribute?.Value ?? false;

        if (isPublic)
        {
            await next(context);
            return;
        }

        // Get the policy attribute
        var AuthPolicyAttribute = endpoint?.Metadata.GetMetadata<AuthPolicyAttribute>();

        var resource = AuthPolicyAttribute?.Resource ?? string.Empty;
        var scope = AuthPolicyAttribute?.Scope ?? Scope.None;

        // Enforce the policy
        if (!await _policyEnforcer.EnforcePolicy(resource, scope, context))
        {
            throw new UnauthorizedException("Access denied");
        }

        await next(context);
    }
}