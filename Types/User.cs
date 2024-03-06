using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrinterManagerServer.Types;

public class User
{
    [Key] [DatabaseGenerated(DatabaseGeneratedOption.Identity)] public Guid Guid { get; set; }
    public required string Username { get; set; }
    public required string Password { get; set; }
}