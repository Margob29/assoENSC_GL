using Microsoft.AspNetCore.Mvc;
using ENSC.Data;
using Microsoft.EntityFrameworkCore;
using ENSC.Models;

namespace ENSC.Controllers;

public class StudentController : Controller
{
    private readonly ENSCContext _context;
    public StudentController(ENSCContext context)
    {
        _context = context;
    }

    //GET all the students
    public async Task<IActionResult> Index()
    {
        var students = await _context.Students
        .ToListAsync();
        return View(students);
    }

    public async Task<IActionResult> Create()
    {
        return View();
    }

    // [HttpPost]
    public async Task<ActionResult<Student>> CreateResult(StudentDto studentDTO)
    {
        // Valider les données du formulaire
        if (!ModelState.IsValid)
        {
            ViewBag.ErrorMessage = "Le nom et l'adresse mail et l'année de promotion, sont obligatoires";
            return View("Create");
        }

        // Créer un nouveau groupe à partir des données du formulaire
        Student student = new Student(studentDTO);
        try
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
        }
        catch
        {
            ViewBag.ErrorMessage = "Il existe déjà un étudiant avec cette adresse mail";
            return View("Create");
        }

        await _context.SaveChangesAsync();



        // Retourner un code de réponse 201 (Created) avec l'URL du nouveau groupe
        return Redirect("/Student");
    }

    public async Task<ActionResult<Student>> Delete(int id)
    {
        var _student = await _context.Students.Where(g => g.Id == id).SingleOrDefaultAsync();
        return View(_student);
    }
    public async Task<ActionResult<Student>> DeleteStudent(int id)
    {
        var student = _context.Students.Where(r => r.Id == id).Single();
        try
        {
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
        }
        catch
        {
            ViewBag.ErrorMessage = "Cet étudiant n'existe pas";
        }
        return Redirect("/Student");
    }

}