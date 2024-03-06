using PrinterManagerServer.Types;

namespace PrinterManagerServer.Database;

public partial class DatabaseContext
{
    public void AddToken(Token token)
    {
        Tokens.Add(token);
        SaveChanges();
    }
}