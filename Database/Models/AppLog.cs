using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DockerConsoleTest.Database.Models;

[Table("AppLogs")]
public class AppLog
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string? MachineName { get; set; }
    public string? InfoString { get; set; }
    public DateTime? CreatedDate { get; set; } = DateTime.Now;

}
