namespace WebProjectEvent.Models;

public class Category
{
    public int CategoryId { get; set; }
    public string CategoryName { get; set; } = null!;
    public string CategoryUrl { get; set; } = null!;

    // Bağlantı -->

    public List<Event> Events { get; set; } = new();
}