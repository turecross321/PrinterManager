namespace PrinterManagerServer.Types.Requests;

public class RegisterRequest
{
    public required string Username { get; set; }
    public required string Email { get; set; }
    public required string PasswordSha512 { get; set; }
}