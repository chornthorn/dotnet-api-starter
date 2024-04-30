using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using DotNetApp.Core.attribute;
using DotNetApp.Core.Security;
using Microsoft.IdentityModel.Tokens;

namespace DotNetApp.Core.Serivce;

[Injectable(scoped: false)]
public class JwtService(RsaKeyProvider rsaKeyProvider)
{
    private readonly RSA _privateRsa = rsaKeyProvider.GetRsaPrivateKey();
    private readonly RSA _publicRsa = rsaKeyProvider.GetRsaPublicKey();

    public string GenerateToken(string sub)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[] { new Claim("sub", sub) }),
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials = new SigningCredentials(new RsaSecurityKey(_privateRsa), SecurityAlgorithms.RsaSha256)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    public bool ValidateToken(string token)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        try
        {
            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new RsaSecurityKey(_publicRsa),
                ValidateIssuer = false,
                ValidateAudience = false
            }, out SecurityToken validatedToken);
        }
        catch
        {
            return false;
        }

        return true;
    }

    public bool ValidateToken(string token, RSA rsa)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        try
        {
            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new RsaSecurityKey(rsa),
                ValidateIssuer = false,
                ValidateAudience = false
            }, out SecurityToken validatedToken);
        }
        catch
        {
            return false;
        }

        return true;
    }
}