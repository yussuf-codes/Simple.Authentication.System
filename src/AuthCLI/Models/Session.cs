namespace AuthCLI.Models;

public class Session
{
    public required string Username { get; set; }
    public required string Token { get; set; }
    public required bool IsValid { get; set; }
    public DateTime CreatedAt = DateTime.Now;
}
