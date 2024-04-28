using DotNetApp.Core.Enum;

namespace DotNetApp.Core.Security;

public class PolicyEnforcer(HttpClient httpClient,IConfiguration configuration)
{
    public async Task<bool> EnforcePolicy(string resource, Scope scope)
    {
        Console.WriteLine($"Enforcing policy for resource: {resource} and scope: {scope.AsString()}");
        
        // Construct the URL for the Keycloak server
        var baseUrl = configuration["keycloak:url"];
        var url = $"https://your-keycloak-server/authz/authorize?resource={resource}&scope={scope.AsString()}";

        try
        {
            // Make a GET request to the Keycloak server
            var response = await httpClient.GetAsync(url);

            // If the response status code is 200 (OK), the policy is enforced
            return response.IsSuccessStatusCode;
        }
        catch (Exception e)
        {
            // Log the exception and return false
            Console.WriteLine($"An error occurred while enforcing the policy: {e.Message}");
            return false;
        }
    }
}