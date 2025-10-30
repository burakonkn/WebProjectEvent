namespace WebProjectEvent.Models;

public class Event
{
    public int EventId { get; set; }
    public string EventName { get; set; } = null!;
    public string EventDescription { get; set; } = null!;
    public double EventPrice { get; set; }
    public string EventImage { get; set; } = null!;
    public DateOnly EventDate { get; set; }
    public string EventTime { get; set; } = null!;
    public string EventLocation { get; set; } = null!;
    public int EventSubscriber { get; set; }
    public bool EventIsActive { get; set; }
    public bool EventIsHome { get; set; }


    // Bağlantı -->

    public int CategoryId { get; set; }
    public Category Category { get; set; } = null!;

    public int LocationId { get; set; }
    public Location Location { get; set; } = null!;

    public List<UserEvent> UserEvents { get; set; } = new();
}