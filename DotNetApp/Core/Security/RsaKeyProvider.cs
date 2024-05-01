using System.Security.Cryptography;
using DotNetApp.Core.attribute;
using DotNetApp.Core.Classes;

namespace DotNetApp.Core.Security;

[Injectable(lifetime: ServiceLifetime.Singleton)]
public class RsaKeyProvider(IHostEnvironment environment, IConfiguration configuration)
{
    public RSA GetRsaPrivateKey()
    {
        var privateKeyPath = Path.Combine(environment.ContentRootPath, configuration["Jwt:RsaPrivateKeyPath"]);
        var privateKey = File.ReadAllText(privateKeyPath);
        var rsa = RSA.Create();
        rsa.ImportFromPem(privateKey);
        return rsa;
    }

    public RSA GetRsaPublicKey()
    {
        var publicKeyPath = Path.Combine(environment.ContentRootPath, configuration["Jwt:RsaPublicKeyPath"]);
        var publicKey = File.ReadAllText(publicKeyPath);
        var rsa = RSA.Create();
        rsa.ImportFromPem(publicKey);
        return rsa;
    }
    
    public RSA GetRsaPublicKey(string publicKey)
    {
        var rsa = RSA.Create();
        rsa.ImportFromPem(publicKey);
        return rsa;
    }
    
    public RSA CreateRsaFromJwk(JWK jwk)
    {
        var rsa = RSA.Create();
        var rsaParameters = new RSAParameters
        {
            Modulus = Base64UrlDecode(jwk.N),
            Exponent = Base64UrlDecode(jwk.E)
        };
        rsa.ImportParameters(rsaParameters);
        return rsa;
    }

    private byte[] Base64UrlDecode(string base64Url)
    {
        var base64 = base64Url.Replace('-', '+').Replace('_', '/');
        switch (base64.Length % 4)
        {
            case 2: base64 += "=="; break;
            case 3: base64 += "="; break;
        }
        return Convert.FromBase64String(base64);
    }
}