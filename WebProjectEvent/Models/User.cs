namespace WebProjectEvent.Models;

public class User
{
    public int UserId { get; set; }
    public string UserName { get; set; } = null!;
    public string UserSurname { get; set; } = null!;
    public string UserMail { get; set; } = null!;
    public string UserPhoneNumber { get; set; } = null!;
    public int UserTicket { get; set; }

    // Bağlantı -->

    public List<UserEvent> UserEvents { get; set; } = new();
}