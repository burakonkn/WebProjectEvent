namespace WebProjectEvent.Models;

public class AdminEventGetModel
{
    public int EventId { get; set; }
    public string EventName { get; set; } = null!;
    public double EventPrice { get; set; }
    public DateOnly EventDate { get; set; }
    public string EventLocation { get; set; } = null!;
    public int EventSubscriber { get; set; }
}