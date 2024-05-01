using DotNetApp.Core.attribute;
using DotNetApp.Core.Classes;
using Newtonsoft.Json;

namespace DotNetApp.Core.Security;

[Injectable(lifetime: ServiceLifetime.Singleton)]
public class JWKSManager(IConfiguration configuration, HttpClient httpClient)
{
    public async Task<JWKS> GetJWKSAsync()
    {
        Console.WriteLine("Loading JWKS...");
        var baseUrl = configuration["keycloak:url"];
        var jwksUri = configuration["keycloak:jwks:uri"];

        var response = await httpClient.GetAsync(baseUrl + jwksUri);
        var jwks = await response.Content.ReadAsStringAsync();

        var jwksObject = JsonConvert.DeserializeObject<JWKS>(jwks);

        if (jwksObject?.Keys == null || !jwksObject.Keys.Any())
        {
            throw new Exception("The JWKS endpoint did not contain any keys");
        }

        Console.WriteLine("JWKS loaded successfully");
        return jwksObject;
    }
}