using Microsoft.AspNetCore.Mvc;
using PrinterManagerServer.Database;
using PrinterManagerServer.Types;
using PrinterManagerServer.Types.Responses;
using static BCrypt.Net.BCrypt;
using LoginRequest = PrinterManagerServer.Types.Requests.LoginRequest;
using RegisterRequest = PrinterManagerServer.Types.Requests.RegisterRequest;

namespace PrinterManagerServer.Controllers;

[ApiController]
[Route("auth")]
public class AuthenticationController: Controller
{
    private const int BcryptWorkFactor = 13;
    
    [HttpPost("register")]
    public IActionResult Register([FromBody] RegisterRequest request)
    {
        using DatabaseContext db = new();
        
        User? user = db.GetUserWithUsername(request.Username);
        
        if (user != null)
            return Conflict();

        
        // todo: validate username, check if password is sha512
        
        user = new User()
        {
            Username = request.Email,
            Password = HashPassword(request.PasswordSha512.ToLower(), BcryptWorkFactor)
        };
        db.AddUser(user);
        
        return Ok(new UserResponse(user));
    }

    private const int AccessTokenExpiryHours = 4;
    private const int RefreshTokenExpiryHours = 24 * 30; // 1 month
    
    [HttpPost("login")]
    public IActionResult LogIn([FromBody] LoginRequest request)
    {
        using DatabaseContext db = new();
        User? user = db.GetUserWithUsername(request.Username);
        
        if (user == null) 
            return Forbid();
        
        // in case work factor has been changed
        if (PasswordNeedsRehash(user.Password, BcryptWorkFactor))
            db.SetUserPassword(user, HashPassword(user.Password, BcryptWorkFactor));
        
        if (!Verify(request.PasswordSha512, user.Password))
            return Forbid();

        Token access = new()
        {
            User = user,
            ExpiryDate = DateTimeOffset.UtcNow.AddHours(AccessTokenExpiryHours),
            TokenType = TokenType.Access
        };
        db.AddToken(access);

        Token refresh = new()
        {
            User = user,
            ExpiryDate = DateTimeOffset.UtcNow.AddHours(RefreshTokenExpiryHours),
            TokenType = TokenType.Refresh
        };
        db.AddToken(refresh);
        
        return Ok(new LoginResponse(access, refresh, user));
    }
    
    // TODO: REFRESH TOKEN
    // TODO: AUTHENTICATION PROVIDER
}