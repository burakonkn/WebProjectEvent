using Microsoft.AspNetCore.Mvc;

namespace WebProjectEvent.Controllers;

public class EventController : Controller
{
    public ActionResult Index()
    {
        return View();
    }
}