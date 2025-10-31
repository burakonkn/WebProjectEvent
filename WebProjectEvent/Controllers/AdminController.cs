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
        ViewBag.AdminActivePage = "AdminEtkinlikler";
        return View(entity);
    }

    public ActionResult RegisterUser()
    {
        ViewBag.AdminActivePage = "AdminKayitlar";
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

        if (model.EventImage == null || model.EventImage.Length == 0)
        {
            ModelState.AddModelError("EventImage", "Görsel Seçmelisiniz!");
        }

        if (ModelState.IsValid)
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
        return View(model);
    }

    [HttpGet]
    public ActionResult EventEdit(int id)
    {
        var entity = _context.Events.FirstOrDefault(x => x.EventId == id);

        if (entity == null)
        {
            return NotFound();
        }

        ViewBag.Categories = new SelectList(_context.Categories.ToList(), "CategoryId", "CategoryName", entity.CategoryId);
        ViewBag.Locations = new SelectList(_context.Locations.ToList(), "LocationId", "LocationName", entity.LocationId);

        var model = new AdminEventEditModel()
        {
            EventName = entity.EventName,
            EventDescription = entity.EventDescription,
            EventPrice = entity.EventPrice,
            EventDate = entity.EventDate,
            EventLocation = entity.EventLocation,
            EventSubscriber = entity.EventSubscriber,
            EventTime = entity.EventTime,
            EventIsActive = entity.EventIsActive,
            EventIsHome = entity.EventIsHome,
            EventImageName = entity.EventImage,
            CategoryId = entity.CategoryId,
            LocationId = entity.LocationId
        };

        return View(model);
    }

    [HttpPost]
    public async Task<ActionResult> EventEdit(int id, AdminEventEditModel model)
    {
        var entity = _context.Events.FirstOrDefault(x => x.EventId == id);

        if (entity?.EventId != id)
        {
            return RedirectToAction("Event", "Admin");
        }

        if (ModelState.IsValid)
        {
            if (entity != null)
            {
                if (model.EventImage != null)
                {
                    var fileName = Path.GetRandomFileName() + ".jpg";
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", fileName);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await model.EventImage!.CopyToAsync(stream);
                    }

                    entity!.EventImage = fileName;
                }

                entity.EventName = model.EventName;
                entity.EventDescription = model.EventDescription;
                entity.CategoryId = model.CategoryId;
                entity.LocationId = model.LocationId;
                entity.EventDate = model.EventDate;
                entity.EventTime = model.EventTime;
                entity.EventSubscriber = model.EventSubscriber;
                entity.EventPrice = model.EventPrice;
                entity.EventLocation = model.EventLocation;
                entity.EventIsActive = model.EventIsActive;
                entity.EventIsHome = model.EventIsHome;

                _context.SaveChanges();

                return RedirectToAction("Event", "Admin");
            }
        }
        return View(model);
    }

    [HttpPost]
    public ActionResult EventDelete(int id)
    {
        var entity = _context.Events.Find(id);

        if (entity != null)
        {
            if (!string.IsNullOrEmpty(entity.EventImage))
            {
                var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", entity.EventImage);
                if (System.IO.File.Exists(imagePath))
                {
                    System.IO.File.Delete(imagePath);
                }
            }

            _context.Events.Remove(entity);
            _context.SaveChanges();
        }

        return RedirectToAction("Event", "Admin");
    }
}