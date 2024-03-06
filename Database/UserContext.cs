using PrinterManagerServer.Types;

namespace PrinterManagerServer.Database;

public partial class DatabaseContext
{
    public User? GetUserWithUsername(string username) => Users.FirstOrDefault(u => u.Username.Equals(username));

    public void AddUser(User user)
    {
        Users.Add(user);
        SaveChanges();
    }

    public void SetUserPassword(User user, string bcryptHash)
    {
        user.Password = bcryptHash;
        SaveChanges();
    }
}