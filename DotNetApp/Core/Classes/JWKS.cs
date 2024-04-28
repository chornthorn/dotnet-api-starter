using Newtonsoft.Json;

namespace DotNetApp.Core.Classes;

public class JWKS
{
    public List<JWK> Keys { get; set; }
}

public class JWK
{
    public string Kid { get; set; }
    public string Kty { get; set; }
    public string Alg { get; set; }
    public string Use { get; set; }
    public string N { get; set; }
    public string E { get; set; }
    public List<string> X5c { get; set; }
    public string X5t { get; set; }
    [JsonProperty("x5t#S256")]
    public string X5tS256 { get; set; }
}