using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

    // GET: Member/Create?id=5
    public async Task<IActionResult> Create(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var e = await _context.Groups
        .SingleOrDefaultAsync(s => s.Id == id);

        if (e == null)
        {
            return NotFound();
        }

        // Liste des roles jamais utilisé dans le groupe
        var memberRolesQuery = _context.Roles.Where(r => !_context.Members.Any(m => m.Group.Id == id && m.Role.Id == r.Id)).ToList();
        var memberStudentQuery = _context.Students.Where(r => !_context.Members.Any(m => m.Group.Id == id && m.Student.Id == r.Id)).ToList();

        if (memberRolesQuery.Count() == 0)
        {
            ViewBag.ErrorMessageRole = "Vous n'avez plus de rôle disponible pour ce groupe, créez en un pour pouvoir ajouter un membre ";
        }
        else if (memberStudentQuery.Count() == 0)
        {
            ViewBag.ErrorMessageStudent = "Vous n'avez plus d'étudiant disponible pour ce groupe, créez en un pour pouvoir ajouter un membre ";

        }

        ViewData["Group"] = e;
        ViewData["Role"] = new SelectList(memberRolesQuery, "Id", "Name"); ;
        ViewData["Student"] = new SelectList(memberStudentQuery, "Id", "Name");

        return View();
    }

    // [HttpPost]
    public async Task<ActionResult<Member>> CreateMember(MemberDTO memberDTO)
    {
        // Valider les données du formulaire
        if (ModelState.IsValid)
        {
            // Créer un nouveau groupe à partir des données du formulaire
            Member member = new Member(memberDTO);

            _context.Members.Add(member);
            await _context.SaveChangesAsync();

        }
        // Retourner un code de réponse 201 (Created) avec l'URL du nouveau groupe
        return Redirect("/Group");
    }
}