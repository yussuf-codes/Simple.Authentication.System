namespace AuthCLI.Models;

internal class User
{
    public required string Username { get; set; }
    public required string PasswordHash { get; set; }
    public required string Salt { get; set; }
}
