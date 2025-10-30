namespace WebProjectEvent.Models;

public class Admin
{
    public int AdminId { get; set; }
    public string AdminUsername { get; set; } = null!;
    public string AdminMail { get; set; } = null!;
    public string AdminPassword { get; set; } = null!;
}