namespace PrinterManagerServer.Types.Requests;

public class LoginRequest
{
    public required string Username { get; set; }
    public required string PasswordSha512 { get; set; }
}