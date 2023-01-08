using Microsoft.AspNetCore.Mvc;
using ENSC.Data;
using ENSC.Models;
using Microsoft.EntityFrameworkCore;

namespace ENSC.Controllers;

[Route("api/[controller]")]
[ApiController]

public class RoleApiController : ControllerBase
{
    private readonly ENSCContext _context;
    public RoleApiController(ENSCContext context)
    {
        _context = context;
    }

    // --------------- READ -----------------
    //Get groups
    [Route("GetRoles")]
    public async Task<ActionResult<IEnumerable<Role>>> GetRoles()
    {
        var roles = _context.Roles;
        return await roles.ToListAsync();
    }

    //Get an group with his id  
    [HttpGet("{id}")]
    public async Task<ActionResult<Role>> GetRole(int id)
    {
        var _role = await _context.Roles
        .Where(s => s.Id == id)
            .SingleOrDefaultAsync();

        if (_role == null)
            return NotFound();

        return _role;
    }

    // --------------- CREATE -----------------
    [HttpPost]
    public async Task<ActionResult<Role>> CreateRole(RoleDTO roleDTO)
    {

        Role _role = new Role(roleDTO);
        _context.Roles.Add(_role);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(CreateRole), new { id = _role.Id }, _role);
    }

    // --------------- DELETE -----------------
    // DELETE: api/RoleApi/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteRole(int id)
    {
        var role = await _context.Roles.FindAsync(id);
        if (role == null)
            return NotFound();
        _context.Roles.Remove(role);
        await _context.SaveChangesAsync();
        return NoContent();
    }

    // --------------- UPDATE -----------------
    //Update an role with his id
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateRole(int id, RoleDTO roleDTO)
    {
        if (id != roleDTO.Id) return BadRequest();

        Role _role = new Role(roleDTO);

        _context.Entry(_role).State = EntityState.Modified;
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
        return _context.Groups.Any(m => m.Id == id);
    }
}