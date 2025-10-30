using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WebProjectEvent.Models;

namespace WebProjectEvent.Controllers;

public class AdminController : Controller
{

    private readonly DataContext _context;

    public AdminController(DataContext context)
    {
        _context = context;
    }

    public ActionResult Event()
    {
        var entity = _context.Events.Select(x => new AdminEventGetModel
        {
            EventId = x.EventId,
            EventName = x.EventName,
            EventLocation = x.EventLocation,
            EventPrice = x.EventPrice,
            EventDate = x.EventDate,
            EventSubscriber = x.EventSubscriber
        }).ToList();
        return View(entity);
    }

    public ActionResult RegisterUser()
    {
        return View();
    }

    public ActionResult Login()
    {
        return View();
    }

    [HttpGet]
    public ActionResult EventCreate()
    {
        ViewBag.Categories = new SelectList(_context.Categories.ToList(), "CategoryId", "CategoryName");
        ViewBag.Locations = new SelectList(_context.Locations.ToList(), "LocationId", "LocationName");
        return View();
    }

    [HttpPost]
    public async Task<ActionResult> EventCreate(AdminEventCreateModel model)
    {

        var fileName = Path.GetRandomFileName() + ".jpg";
        var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", fileName);

        using (var stream = new FileStream(path, FileMode.Create))
        {
            await model.EventImage!.CopyToAsync(stream);
        }

        var entity = new Event()
        {
            EventName = model.EventName,
            EventDescription = model.EventDescription,
            EventPrice = model.EventPrice,
            EventDate = model.EventDate,
            EventLocation = model.EventLocation,
            EventSubscriber = model.EventSubscriber,
            EventTime = model.EventTime,
            EventIsActive = model.EventIsActive,
            EventIsHome = model.EventIsHome,
            EventImage = fileName,
            CategoryId = model.CategoryId,
            LocationId = model.LocationId
        };

        _context.Events.Add(entity);
        _context.SaveChanges();

        return RedirectToAction("Event", "Admin");
    }

    public ActionResult EventEdit()
    {
        return View();
    }
}