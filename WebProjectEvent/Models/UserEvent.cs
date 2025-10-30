namespace WebProjectEvent.Models;

public class UserEvent
{
    public int UserEventId { get; set; }

    // Bağlantı -->

    public int UserId { get; set; }
    public User User { get; set; } = null!;

    public int EventId { get; set; }
    public Event Event { get; set; } = null!;
}