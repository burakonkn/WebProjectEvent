namespace WebProjectEvent.Models;

public class Location
{
    public int LocationId { get; set; }
    public string LocationName { get; set; } = null!;
    public string LocationUrl { get; set; } = null!;

    // Bağlantı -->

    public List<Event> Events { get; set; } = new();
}