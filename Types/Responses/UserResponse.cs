namespace PrinterManagerServer.Types.Responses;

public class UserResponse(User user)
{
    public Guid Guid { get; set; } = user.Guid;
    public string Username { get; set; } = user.Username;
}