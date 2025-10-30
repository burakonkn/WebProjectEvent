using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebProjectEvent.Models;

namespace WebProjectEvent.Controllers;

public class HomeController : Controller
{
    private readonly DataContext _context;
    public HomeController(DataContext context)
    {
        _context = context;
    }
    public ActionResult Index()
    {
        var entity = _context.Events.Where(x => x.EventIsActive && x.EventIsHome).Select(x => new EventGetModel
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
        }).Take(3).ToList();
        ViewData["EventCount"] = _context.Events.Count();
        ViewData["UserCount"] = _context.Users.Count();
        ViewData["CityCount"] = _context.Locations.Count();
        return View(entity);
    }
}
