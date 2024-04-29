using System.Net;
using System.Net.Http.Headers;
using DotNetApp.Core.Enum;

namespace DotNetApp.Core.Security;

public class PolicyEnforcer(HttpClient httpClient, IConfiguration configuration)
{
    public async Task<bool> EnforcePolicy(string resource, Scope scope, HttpContext context)
    {
        Console.WriteLine($"Enforcing policy for resource: {resource} and scope: {scope.AsString()}");

        // Construct the URL for the Keycloak server
        var baseUrl = configuration["keycloak:url"];
        var realm = configuration["keycloak:client:realm"];
        var clientId = configuration["keycloak:client:client_id"];
        var url = $"{baseUrl}/realms/{realm}/protocol/openid-connect/token";
        var grantType = "urn:ietf:params:oauth:grant-type:uma-ticket";
        var permission = $"{resource}#{scope.AsString()}";

        // get access token from header

        // check if the access token is present in the request header
        if (!context.Request.Headers.ContainsKey("Authorization"))
        {
            Console.WriteLine("Access token is missing in the request header");
            return false;
        }

        var accessToken = context.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");

        // Create a new form URL encoded content
        var content = new FormUrlEncodedContent(new Dictionary<string, string>
        {
            { "grant_type", grantType },
            { "permission", permission },
            { "audience", clientId },
            { "response_mode", "decision" }
        });

        // add access token to the request header
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

        try
        {
            // Send a POST request to the Keycloak server
            var response = await httpClient.PostAsync(url, content);
            response.EnsureSuccessStatusCode();

            // Check if the response is 200 OK
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }
            
            return false;
        }
        catch (Exception e)
        {
            // Log the exception and return false
            Console.WriteLine($"An error occurred while enforcing the policy: {e.Message}");
            return false;
        }
    }
}