namespace DotNetApp.Core.Helper;

public class HashTextHelper
{
    public string Hash(string password)
    {
        // Generate a salt and hash the password
        string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password, BCrypt.Net.BCrypt.GenerateSalt());
        return hashedPassword;
    }

    public bool Verify(string hashedPassword, string providedPassword)
    {
        // Verify the provided password against the hashed password
        return BCrypt.Net.BCrypt.Verify(providedPassword, hashedPassword);
    }
}