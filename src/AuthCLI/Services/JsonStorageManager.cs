using System.Text.Json;
using AuthCLI.Models;

namespace AuthCLI.Services;

internal static class JsonStorageManager
{
    private static string UsersDatabasePath = "Database/Users.json";

    public static List<User>? Read()
    {
        using StreamReader reader = new StreamReader(UsersDatabasePath);
            return JsonSerializer.Deserialize<List<User>>(reader.ReadToEnd());
    }

    public static void Write(List<User> users)
    {
        using StreamWriter outputFile = new StreamWriter(UsersDatabasePath);
            outputFile.Write(JsonSerializer.Serialize(users, new JsonSerializerOptions() { WriteIndented = true }));
    }
}
