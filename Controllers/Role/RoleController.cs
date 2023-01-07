using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ENSC.Data;
using Microsoft.EntityFrameworkCore;
using ENSC.Models;

namespace ENSC.Controllers;

public class RoleController : Controller
{
    private readonly ENSCContext _context;
    public RoleController(ENSCContext context)
    {
        _context = context;
    }

    //GET all the groups
    public async Task<IActionResult> Index()
    {
        var roles = await _context.Roles
        .ToListAsync();

        return View(roles);
    }

    public async Task<IActionResult> Create()
    {
        return View();
    }

    // [HttpPost]
    public async Task<ActionResult<Role>> CreateResult(RoleDTO roleDTO)
    {
        // Valider les données du formulaire
        if (!ModelState.IsValid)
        {
            ViewBag.ErrorMessage = "Il est obligatoire de renseigner un nom";
            return View("Create");
        }

        // Créer un nouveau groupe à partir des données du formulaire
        Role role = new Role(roleDTO);
        try
        {
            _context.Roles.Add(role);
            await _context.SaveChangesAsync();
        }
        catch
        {
            ViewBag.ErrorMessage = "Il existe déjà un rôle avec ce nom";
            return View("Create");
        }

        // Retourner un code de réponse 201 (Created) avec l'URL du nouveau role
        return Redirect("/Role");
    }

    public async Task<ActionResult<Role>> Delete(int id)
    {
        var role = _context.Roles.Where(r => r.Id == id).Single();
        try
        {
            _context.Roles.Remove(role);
            await _context.SaveChangesAsync();
        }
        catch
        {
            ViewBag.ErrorMessage = "Ce role n'existe pas";
        }
        return Redirect("/Role");
    }

}