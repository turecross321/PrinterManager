using Microsoft.EntityFrameworkCore;
using PrinterManagerServer.Types;
using PrinterManagerServer.Types.Responses;

namespace PrinterManagerServer.Database;

public partial class DatabaseContext: DbContext
{
    private DbSet<User> Users { get; set; }
    private DbSet<Token> Tokens { get; set; }
    private DbSet<PrinterModel> PrinterModels { get; set; }
    private DbSet<Printer> Printers { get; set; }
    private DbSet<PrinterReport> PrinterReports { get; set; }

    private string DbPath { get; }

    public DatabaseContext()
    {
        Environment.SpecialFolder folder = Environment.SpecialFolder.LocalApplicationData;
        string path = Path.Combine(Environment.GetFolderPath(folder), "PrinterManagerServer");

        if (!Path.Exists(path))
            Directory.CreateDirectory(path);
        
        DbPath = Path.Join(path, "database.db");
    }

    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
}