namespace AuthCLI.Services;

internal static class Validator
{
    public static bool IsNullOrEmptyString(string? str)
    {
        return str is null || str == "";
    }

    public static bool UsernameContainsSpace(string username)
    {
        for (int i = 0; i < username.Length; i++)
        {
            if (username[i] == ' ')
                return true;
        }
        return false;
    }

    public static bool CheckPasswordLength(string password)
    {
        return password.Length >= 8;
    }
}
