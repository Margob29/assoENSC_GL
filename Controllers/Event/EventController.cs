using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using projet_alex_margo.Models;

namespace projet_alex_margo.Controllers;

public class EventController : Controller
{

    public IActionResult Event()
    {
        return View();
    }
    public IActionResult Details()
    {
        return View();
    }
}