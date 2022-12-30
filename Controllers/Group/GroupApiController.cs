using Microsoft.AspNetCore.Mvc;
using ENSC.Data;
using ENSC.Models;
using Microsoft.EntityFrameworkCore;

namespace ENSC.Controllers;

[Route("api/[controller]")]
[ApiController]

public class GroupApiController : ControllerBase
{
    private readonly ENSCContext _context;
    public GroupApiController(ENSCContext context)
    {
        _context = context;
    }

    // --------------- READ -----------------
    //Get groups
    public async Task<ActionResult<IEnumerable<Group>>> Getgroups()
    {
        var groups = _context.Groups;
        return await groups.ToListAsync();
    }

    //Get an group with his id
    [HttpGet("{id}")]
    public async Task<ActionResult<Group>> GetGroup(int id)
    {
        var _group = await _context.Groups
            .Where(s => s.Id == id)
            .Include(s => s.Events)
            .Include(s => s.Students)
            .SingleOrDefaultAsync();

        if (_group == null)
            return NotFound();

        return _group;
    }

    // --------------- CREATE -----------------
    [HttpPost]
    public async Task<ActionResult<Group>> CreateGroup(GroupDTO groupDTO)
    {

        Group _group = new Group(groupDTO);
        //var president = _context.Students.Find(_group.PresidentId);
        //_group.President = president!;
        _context.Groups.Add(_group);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(CreateGroup), new { id = _group.Id }, _group);
    }
}