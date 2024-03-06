namespace PrinterManagerServer.Types.Responses;

public class TokenResponse(Token token)
{
    public Guid Guid { get; set; } = token.Guid;
    public DateTimeOffset CreationDate { get; set; } = token.CreationDate;
    public DateTimeOffset ExpiryDate { get; set; } = token.ExpiryDate;
    public TokenType TokenType { get; set; } = token.TokenType;
}