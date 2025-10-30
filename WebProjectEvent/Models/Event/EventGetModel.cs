using System.ComponentModel.DataAnnotations;

namespace WebProjectEvent.Models;

public class EventGetModel
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
    public string CategoryName { get; set; } = null!;


    // Bağlantı -->

    public int CategoryId { get; set; }

    public int LocationId { get; set; }
}