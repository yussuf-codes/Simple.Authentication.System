using System.Diagnostics;
using AuthCLI.Models;

namespace AuthCLI.Services;

internal static class Authenticator
{
    public static void Register(string username, string password)
    {
        string randomSalt = Cryptographer.GenerateRandomSalt();
        string passwordHash = Cryptographer.ComputeSHA256Hash(password + randomSalt);

        List<User>? users = DatabaseClient.Read();

        if (users is null)
            users = new List<User>();

        User? user = users.Find(user => user.Username == username);

        if (user is not null)
            Console.WriteLine("Username already taken!");

        users.Add(new User() { Username = username, PasswordHash = passwordHash, Salt = randomSalt });

        DatabaseClient.Write(users);

        Console.WriteLine("Registered successfully!");
    }

    public static void LogIn(string username, string password)
    {
        List<User>? users = DatabaseClient.Read();

        if (users is null)
        {
            Console.WriteLine("User not found!");
            return;
        }

        User? user = users.Find(user => user.Username == username);

        if (user is null)
        {
            Console.WriteLine("User not found!");
            return;
        }

        string passwordHash = Cryptographer.ComputeSHA256Hash(password + user.Salt);

        if (passwordHash != user.PasswordHash)
        {
            Console.WriteLine("Wrong Password!");
            return;
        }

        Console.Clear();
        Console.WriteLine("Logged in Successfully!");
        string token = Convert.ToString(Guid.NewGuid())!;
        SessionsManager.Add(new Session() { Username = username, Token = token, IsValid = true });
        Console.WriteLine($"Session Token: {token}");
    }

    public static void LogOut(string username, string token)
    {
        SessionsManager.InvalidateSession(username, token);
    }
}
