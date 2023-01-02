using Microsoft.AspNetCore.Mvc;
using ENSC.Data;
using Microsoft.EntityFrameworkCore;
using ENSC.Models;

namespace ENSC.Controllers;

public class MemberController : Controller
{
    private readonly ENSCContext _context;
    public MemberController(ENSCContext context)
    {
        _context = context;
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