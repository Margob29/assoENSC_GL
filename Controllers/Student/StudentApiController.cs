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

    //Update an student with his id
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateStudent(int id, StudentDto studentDto)
    {
        if (id != studentDto.Id) return BadRequest();

        Student _student = new Student(studentDto);

        _context.Entry(_student).State = EntityState.Modified;
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
        return _context.Students.Any(m => m.Id == id);
    }

    // ...
    // DELETE: api/StudentApi/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteStudent(int id)
    {
        var student = await _context.Students.FindAsync(id);
        if (student == null)
            return NotFound();
        _context.Students.Remove(student);
        await _context.SaveChangesAsync();
        return NoContent();
    }

}