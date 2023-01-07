using Microsoft.AspNetCore.Mvc;
using ENSC.Data;
using ENSC.Models;
using Microsoft.EntityFrameworkCore;

namespace ENSC.Controllers;

[Route("api/[controller]")]
[ApiController]

public class EventApiController : ControllerBase
{
    private readonly ENSCContext _context;
    public EventApiController(ENSCContext context)
    {
        _context = context;
    }

    // --------------- READ -----------------
    //Get events
    public async Task<ActionResult<IEnumerable<Event>>> GetEvents()
    {
        var events = _context.Events
            .OrderBy(s => s.Date);

        return await events.ToListAsync();
    }

    //Get an event with his id
    [HttpGet("{id}")]
    public async Task<ActionResult<Event>> GetEvent(int id)
    {
        var _event = await _context.Events
            .Where(s => s.Id == id)
            .Include(s => s.Group)
            .SingleOrDefaultAsync();

        if (_event == null)
            return NotFound();

        return _event;
    }

    /*// /!\ Ne fonctionne pas, à revoir
    // --------------- UPDATE -----------------
    //Update an event with his id
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateEvent(int id, Event _event)
    {
        if (id != _event.Id) return BadRequest();

        _context.Entry(_event).State = EntityState.Modified;
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TodoExists(id)) return NotFound();
            else throw;
        }

        return NoContent();
    }
    private bool TodoExists(int id)
    {
        return _context.Events.Any(m => m.Id == id);
    }*/

    // --------------- CREATE -----------------
    [HttpPost]
    public async Task<ActionResult<Event>> CreateEvent(EventDTO eventDTO)
    {

        Event _event = new Event(eventDTO);
        var group = _context.Groups.Find(_event.GroupId);
        _event.Group = group!;
        _context.Events.Add(_event);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(CreateEvent), new { id = _event.Id }, _event);
    }

    

}