using AuthCLI.Services;

namespace AuthCLI;

internal static class Program
{
    private static void Main()
    {
        Console.Clear();

        Console.WriteLine("1. Login");
        Console.WriteLine("2. Register");

        Console.Write($"{Environment.NewLine}> ");

        char key = Console.ReadKey(true).KeyChar;

        if (!(key == '1' || key == '2'))
        {
            Console.Clear();
            Console.WriteLine("Invalid Option!");
            return;
        }

        Console.Clear();

        Console.Write("Username: "); string? username = Console.ReadLine();
        Console.Write("Password: "); string? password = Console.ReadLine();

        if (Validator.IsNullOrEmptyString(username) || Validator.IsNullOrEmptyString(password))
        {
            Console.Clear();
            Console.WriteLine("Username or password is empty!");
            return;
        }

        if (Validator.UsernameContainsSpace(username!))
        {
            Console.Clear();
            Console.WriteLine("Username can not contain spaces!");
            return;
        }

        if (!Validator.CheckPasswordLength(password!))
        {
            Console.Clear();
            Console.WriteLine("Password is less than 8 characters!");
            return;
        }

        Console.Clear();

        if (key == '1')
            Authenticator.LogIn(username!, password!);
        else
            Authenticator.Register(username!, password!);
    }
}
