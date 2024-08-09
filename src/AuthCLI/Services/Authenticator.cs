using AuthCLI.Models;

namespace AuthCLI.Services;

internal static class Authenticator
{
    public static void Register(string username, string password)
    {
        string randomSalt = Cryptographer.GenerateRandomSalt();
        string passwordHash = Cryptographer.ComputeSHA256Hash(password + randomSalt);

        List<User>? users = JsonStorageManager.Read();

        if (users is null)
            users = new List<User>();

        if (users.Count != 0)
        {
            User? existUser = users.Find(user => user.Username == username);
            if (existUser is not null)
            {
                Console.WriteLine("Username already taken!");
                return;
            }
        }

        users.Add(new User() { Username = username, PasswordHash = passwordHash, Salt = randomSalt });

        JsonStorageManager.Write(users);

        Console.WriteLine("Registered successfully!");
    }

    public static void LogIn(string username, string password)
    {
        List<User>? users = JsonStorageManager.Read();

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
            Console.WriteLine("Wrong password!");
            return;
        }

        Console.WriteLine("Logged in successfully!");
    }
}
