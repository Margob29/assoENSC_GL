using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ENSC.Data;
using ENSC.Models;
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

    //========= GET ================
    //All the events
    public async Task<IActionResult> Index(int filter)
    {
        ViewData["filter"] = filter;
        var events = new List<Event>();
        if (filter == 1) events = await _context.Events.Where(s => s.Date > DateTime.Now).Include(s => s.Group).ToListAsync();
        else if (filter == 2) events = await _context.Events.Where(s => s.Date <= DateTime.Now).Include(s => s.Group).ToListAsync();
        else events = await _context.Events.Include(s => s.Group).ToListAsync();
        return View(events);
    }

    //An event with his id
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null) return NotFound();

        var e = await _context.Events.Include(s => s.Group).SingleOrDefaultAsync(s => s.Id == id);
        if (e == null) return NotFound();

        return View(e);
    }

    //================ CREATE =================
    public async Task<IActionResult> Create()
    {
        //Liste de tous les groupes existants
        var groupQuery = await _context.Groups.ToListAsync();
        if (groupQuery.Count() == 0) ViewBag.ErrorMessageGroup = "Aucun club n'existe, créez-en un pour ajouter un évènement !";
        ViewData["Group"] = new SelectList(groupQuery, "Id", "Name");
        return View();
    }
    public async Task<IActionResult> CreateEvent(EventDTO eventDTO)
    {
        // Valider les données du formulaire
        if (ModelState.IsValid)
        {
            eventDTO.Date = DateTime.Now;
            //Création d'un nouvel évènement
            Event _event = new Event(eventDTO);
            _context.Events.Add(_event);
            await _context.SaveChangesAsync();
        }
        return Redirect("/Event");
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