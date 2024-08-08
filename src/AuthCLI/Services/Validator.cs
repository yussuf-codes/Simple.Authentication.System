namespace AuthCLI.Services;

internal static class Validator
{
    public static bool IsNullOrEmptyString(string? str)
    {
        return str is null || str == "";
    }
}
