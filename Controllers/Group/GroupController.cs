using Microsoft.AspNetCore.Mvc;
using ENSC.Data;
using Microsoft.EntityFrameworkCore;
using ENSC.Models;

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
        var groups = await _context.Groups
        .Include(s => s.Events)
        .Include(s => s.Students)
            .ThenInclude(m => m.Student)
        .Include(s => s.Students)
            .ThenInclude(m => m.Role)
        .ToListAsync();
        return View(groups);
    }

    //GET an group with his id
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var e = await _context.Groups
        .Include(s => s.Events)
        .Include(s => s.Students)
            .ThenInclude(m => m.Role)
        .Include(s => s.Students)
            .ThenInclude(m => m.Student)
        .SingleOrDefaultAsync(s => s.Id == id);

        if (e == null)
        {
            return NotFound();
        }
        return View(e);
    }

    public async Task<IActionResult> Create()
    {
        return View();
    }

    // [HttpPost]
    public async Task<ActionResult<Group>> CreateResult(GroupDTO groupDTO)
    {

        ViewBag.Name = groupDTO.Name;
        ViewBag.Description = groupDTO.Description;

        // Valider les données du formulaire
        if (!ModelState.IsValid)
        {
            ViewBag.ErrorMessage = "Le nom et la description sont obligatoires";
            return View("Create");
        }

        // Créer un nouveau groupe à partir des données du formulaire
        Group group = new Group(groupDTO);
        try
        {
            _context.Groups.Add(group);
            await _context.SaveChangesAsync();
        }
        catch
        {
            ViewBag.ErrorMessage = "Il existe déjà un club avec ce nom";
            return View("Create");
        }



        // Retourner un code de réponse 201 (Created) avec l'URL du nouveau groupe
        return Redirect("/Group");
    }

}