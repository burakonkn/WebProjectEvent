using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebProjectEvent.Models;

namespace WebProjectEvent.Controllers;

public class EventController : Controller
{
    private readonly DataContext _context;

    public EventController(DataContext context)
    {
        _context = context;
    }
    public ActionResult Index(int? location, string q, int? category)
    {

        IQueryable<Event> query = _context.Events.Include(x => x.Category);
        query = query.Where(x => x.EventIsActive);

        if (category != null)
        {
            query = query.Where(x => x.CategoryId == category);
        }

        if (location != null)
        {
            query = query.Where(x => x.LocationId == location);
        }

        if (!string.IsNullOrEmpty(q))
        {
            query = query.Where(x => x.EventName.ToLower().Contains(q.ToLower()));
        }

        var eventsList = query.Select(x => new EventGetModel
        {
            EventName = x.EventName,
            EventImage = x.EventImage,
            EventDescription = x.EventDescription,
            EventDate = x.EventDate,
            EventLocation = x.EventLocation,
            EventSubscriber = x.EventSubscriber,
            EventPrice = x.EventPrice,
            EventTime = x.EventTime,
            LocationId = x.LocationId,
            CategoryId = x.CategoryId,
            CategoryName = x.Category.CategoryName,
            LocationName = x.Location.LocationName
        }).ToList();

        ViewBag.Categories = new SelectList(_context.Categories.ToList(), "CategoryId", "CategoryName", category);
        ViewBag.Locations = new SelectList(_context.Locations.ToList(), "LocationId", "LocationName", location);

        ViewData["q"] = q;

        ViewBag.ActivePage = "Etkinlikler";

        return View(eventsList);
    }

    public ActionResult RegisterEvent()
    {
        return View();
    }
}