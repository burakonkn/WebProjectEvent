using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebProjectEvent.Models;

namespace WebProjectEvent.Controllers;

public class HomeController : Controller
{
    public ActionResult Index()
    {
        return View();
    }
}
