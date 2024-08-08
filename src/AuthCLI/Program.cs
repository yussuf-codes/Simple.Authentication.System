using AuthCLI.Services;

namespace AuthCLI;

internal static class Program
{

    private static void Main()
    {
        bool on = true;
        while (on)
        {
            Console.WriteLine("1. Login");
            Console.WriteLine("2. Register");
            Console.WriteLine();
            Console.WriteLine("3. Exit");

            char key = Console.ReadKey(true).KeyChar;

            if (!(key == '1' || key == '2' || key == '3'))
            {
                Console.Clear();
                Console.WriteLine("Invalid Input!");
                return;
            }

            if (key == '3')
            {
                on = false;
                Console.Clear();
                return;
            }

            Console.Clear();

            Console.Write("Username: "); string? username = Console.ReadLine();
            Console.Write("Password: "); string? password = Console.ReadLine();

            if (Validator.IsNullOrEmptyString(username) || Validator.IsNullOrEmptyString(password))
            {
                Console.Clear();
                Console.WriteLine("Invalid Input!");
                return;
            }

            Console.Clear();

            if (key == '1')
            {
                Authenticator.LogIn(username!, password!);
            }
            else if (key == '2')
            {
                Authenticator.Register(username!, password!);
            }
        }
    }
}
