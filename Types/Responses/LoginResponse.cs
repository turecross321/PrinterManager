namespace PrinterManagerServer.Types.Responses;

public class LoginResponse(Token accessToken, Token refreshToken, User user)
{
    public TokenResponse AccessToken { get; set; } = new (accessToken);
    public TokenResponse RefreshToken { get; set; } = new (refreshToken);
    public UserResponse User { get; set; } = new (user);
}