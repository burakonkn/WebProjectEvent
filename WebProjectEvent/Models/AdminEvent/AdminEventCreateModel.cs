using System.ComponentModel.DataAnnotations;

namespace WebProjectEvent.Models;

public class AdminEventCreateModel
{
    public string EventName { get; set; } = null!;
    public string EventDescription { get; set; } = null!;
    public double EventPrice { get; set; }
    public IFormFile EventImage { get; set; } = null!;
    [DataType(DataType.Date)]
    public DateOnly EventDate { get; set; }
    public string EventTime { get; set; } = null!;
    public string EventLocation { get; set; } = null!;
    public int EventSubscriber { get; set; }
    public bool EventIsActive { get; set; }
    public bool EventIsHome { get; set; }


    // Bağlantı -->

    public int CategoryId { get; set; }

    public int LocationId { get; set; }
}