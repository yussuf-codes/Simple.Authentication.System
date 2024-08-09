using System.Security.Cryptography;
using System.Text;

namespace AuthCLI.Services;

internal static class Cryptographer
{
    public static string ComputeSHA256Hash(string password)
    {
        using (SHA256 sha256Hash = SHA256.Create())
        {
            byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
                builder.Append(bytes[i].ToString("x2"));
            return builder.ToString();
        }
    }

    public static string GenerateRandomSalt()
    {
        StringBuilder builder = new StringBuilder();
        for (int i = 0; i < 3; i++)
            builder.Append((char)new Random().Next(97, 123));
        return builder.ToString();
    }
}
