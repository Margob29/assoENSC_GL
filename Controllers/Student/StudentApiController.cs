using Microsoft.AspNetCore.Mvc;
using ENSC.Data;
using ENSC.Models;
using Microsoft.EntityFrameworkCore;

namespace ENSC.Controllers;

[Route("api/[controller]")]
[ApiController]

public class StudentApiController : ControllerBase
{
    private readonly ENSCContext _context;
    public StudentApiController(ENSCContext context)
    {
        _context = context;
    }

    //Get students
    [Route("GetStudents")]
    public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
    {
        var students = _context.Students;
        return await students.ToListAsync();
    }

    // --------------- CREATE -----------------
    [HttpPost]
    public async Task<ActionResult<Student>> CreateStudent(StudentDto studentDto)
    {

        Student _student = new Student(studentDto);
        _context.Students.Add(_student);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(CreateStudent), new { id = _student.Id }, _student);
    }
}