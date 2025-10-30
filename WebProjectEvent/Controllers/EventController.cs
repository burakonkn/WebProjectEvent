using Microsoft.AspNetCore.Mvc;
using WebProjectEvent.Models;

namespace WebProjectEvent.Controllers;

public class EventController : Controller
{
    private readonly DataContext _context;

    public EventController(DataContext context)
    {
        _context = context;
    }
    public ActionResult Index()
    {
        var entity = _context.Events.Where(x => x.EventIsActive).Select(x => new EventGetModel
        {
            EventName = x.EventName,
            EventImage = x.EventImage,
            EventDescription = x.EventDescription,
            EventDate = x.EventDate,
            EventLocation = x.EventLocation,
            EventSubscriber = x.EventSubscriber,
            EventPrice = x.EventPrice,
            EventTime = x.EventTime,
            CategoryName = x.Category.CategoryName
        }).ToList();
        return View(entity);
    }

    public ActionResult RegisterEvent()
    {
        return View();
    }
}