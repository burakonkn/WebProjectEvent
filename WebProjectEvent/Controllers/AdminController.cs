using Microsoft.AspNetCore.Mvc;

namespace WebProjectEvent.Controllers;

public class AdminController : Controller
{
    public ActionResult Event()
    {
        return View();
    }

    public ActionResult RegisterUser()
    {
        return View();
    }

    public ActionResult Login()
    {
        return View();
    }

    public ActionResult EventCreate()
    {
        return View();
    }

    public ActionResult EventEdit()
    {
        return View();
    }
}