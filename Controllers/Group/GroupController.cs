using Microsoft.AspNetCore.Mvc;
using ENSC.Data;
using Microsoft.EntityFrameworkCore;

namespace ENSC.Controllers;

public class GroupController : Controller
{
    private readonly ENSCContext _context;
    public GroupController(ENSCContext context)
    {
        _context = context;
    }

    //GET all the groups
    public async Task<IActionResult> Index()
    {
        var groups = await _context.Groups.Include(s => s.Events).Include(p => p.President).ToListAsync();
        return View(groups);
    }

    //GET an group with his id
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }
        var e = await _context.Groups.Include(s => s.Events).SingleOrDefaultAsync(s => s.Id == id);
        if (e == null)
        {
            return NotFound();
        }
        return View(e);
    }
}