using System.Text.Json;
using AuthCLI.Models;

namespace AuthCLI.Services;

internal static class DatabaseClient
{
    private static string DatabasePath = Path.Combine(Environment.CurrentDirectory, "Database/users.json");

    private static void CheckDatabase()
    {
        if (!File.Exists(DatabasePath))
           return;
    }

    public static List<User>? Read()
    {
        CheckDatabase();
        using (StreamReader reader = new StreamReader(DatabasePath))
        {
            string usersString = reader.ReadToEnd();
            return JsonSerializer.Deserialize<List<User>>(usersString);
        }
    }

    public static void Write(List<User>? users)
    {
        CheckDatabase();
        string jsonString = JsonSerializer.Serialize(users, new JsonSerializerOptions() { WriteIndented = true });
        using (StreamWriter outputFile = new StreamWriter(DatabasePath))
        {
            outputFile.WriteLine(jsonString);
        }
    }
}
