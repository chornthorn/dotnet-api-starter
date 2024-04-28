using DotNetApp.Auth.Dto;
using DotNetApp.Core.attribute;
using DotNetApp.Keycloak.Dto;
using Newtonsoft.Json;

namespace DotNetApp.Keycloak;

[Injectable]
public class KeycloakService(
    IConfiguration configuration,
    HttpClient httpClient)
{
    public async Task<LoginResDto> Login(LoginReqDto loginReqDto)
    {
        try
        {
            var baseUrl = configuration["Keycloak:url"];
            var tokenUrl = configuration["Keycloak:client:token_endpoint"];
            var clientId = configuration["Keycloak:client:client_id"];
            var clientSecret = configuration["Keycloak:client:client_secret"];
            var grantType = configuration["Keycloak:client:grant_type"];

            var form = new Dictionary<string, string>
            {
                { "client_id", clientId },
                { "client_secret", clientSecret },
                { "grant_type", grantType },
                { "username", loginReqDto.Username },
                { "password", loginReqDto.Password },
                { "scope", "openid" }
            };

            var response = await httpClient.PostAsync(baseUrl + tokenUrl, new FormUrlEncodedContent(form));
            var content = await response.Content.ReadAsStringAsync();
            // convert response to dictionary
            var json = JsonConvert.DeserializeObject<Dictionary<string, object>>(content);

            return new LoginResDto
            {
                AccessToken = json["access_token"].ToString(),
                RefreshToken = json["refresh_token"].ToString(),
                TokenType = json["token_type"].ToString(),
                ExpiresIn = int.Parse(json["expires_in"].ToString() ?? "0")
            };
        }
        catch (Exception e)
        {
            throw new Exception("Failed to login", e);
        }
    }

    // refresh token
    public async Task<LoginResDto> RefreshToken(string refreshToken)
    {
        try
        {
            var baseUrl = configuration["Keycloak:url"];
            var tokenUrl = configuration["Keycloak:client:token_endpoint"];
            var clientId = configuration["Keycloak:client:client_id"];
            var clientSecret = configuration["Keycloak:client:client_secret"];
            var grantType = "refresh_token";

            var form = new Dictionary<string, string>
            {
                { "client_id", clientId },
                { "client_secret", clientSecret },
                { "grant_type", grantType },
                { "refresh_token", refreshToken }
            };

            var response = await httpClient.PostAsync(baseUrl + tokenUrl, new FormUrlEncodedContent(form));
            var content = await response.Content.ReadAsStringAsync();
            // convert response to dictionary
            var json = JsonConvert.DeserializeObject<Dictionary<string, object>>(content);

            return new LoginResDto
            {
                AccessToken = json["access_token"].ToString(),
                RefreshToken = json["refresh_token"].ToString(),
                TokenType = json["token_type"].ToString(),
                ExpiresIn = int.Parse(json["expires_in"].ToString() ?? "0")
            };
        }
        catch (Exception e)
        {
            throw new Exception("Failed to refresh token", e);
        }
    }

    // get user info
    public async Task<KUserInfoDto> UserInfo(string accessToken)
    {
        try
        {
            var baseUrl = configuration["Keycloak:url"];
            var userInfoUrl = configuration["Keycloak:client:userinfo_endpoint"];

            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);

            var response = await httpClient.GetAsync(baseUrl + userInfoUrl);
            var content = await response.Content.ReadAsStringAsync();

            // convert response to dictionary
            var json = JsonConvert.DeserializeObject<Dictionary<string, object>>(content);

            return new KUserInfoDto
            {
                Id = json["sub"].ToString(),
                Username = json["preferred_username"].ToString(),
                Email = json["email"].ToString(),
                EmailVerified = bool.Parse(json["email_verified"].ToString() ?? "false"),
                Name = json["name"].ToString(),
                GivenName = json["given_name"].ToString(),
                FamilyName = json["family_name"].ToString(),
            };
        }
        catch (Exception e)
        {
            throw new Exception("Failed to get user info", e);
        }
    }

    // logout
    public async Task Logout(string accessToken)
    {
        try
        {
            var baseUrl = configuration["Keycloak:url"];
            var logoutUrl = configuration["Keycloak:client:logout_endpoint"];

            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);

            await httpClient.PostAsync(baseUrl + logoutUrl, null);
        }
        catch (Exception e)
        {
            throw new Exception("Failed to logout", e);
        }
    }
}