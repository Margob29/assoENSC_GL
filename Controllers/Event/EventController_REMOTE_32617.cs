using Microsoft.AspNetCore.Mvc;
using ENSC.Data;
using Microsoft.EntityFrameworkCore;
using ENSC.Models;

namespace ENSC.Controllers;

public class EventController : Controller
{
    private readonly ENSCContext _context;
    public EventController(ENSCContext context)
    {
        _context = context;
    }

    //GET all the events
    public async Task<IActionResult> Index()
    {
        var events = await _context.Events.Include(s => s.Group).ToListAsync();
        return View(events);
    }

    //GET an event with his id
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }
        var e = await _context.Events.Include(s => s.Group).SingleOrDefaultAsync(s => s.Id == id);
        if (e == null)
        {
            return NotFound();
        }
        return View(e);
    }

    public async Task<ActionResult<Event>> Delete(int id)
    {
        var eventD = _context.Events.Where(r => r.Id == id).Single();
        try
        {
            _context.Events.Remove(eventD);
            await _context.SaveChangesAsync();
        }
        catch
        {
            ViewBag.ErrorMessage = "Cet événement n'existe pas";
        }
        return Redirect("/Event");
    }

}