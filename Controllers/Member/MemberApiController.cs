using Microsoft.AspNetCore.Mvc;
using ENSC.Data;
using ENSC.Models;
using Microsoft.EntityFrameworkCore;

namespace ENSC.Controllers;

[Route("api/[controller]")]
[ApiController]

public class MemberApiController : ControllerBase
{
    private readonly ENSCContext _context;
    public MemberApiController(ENSCContext context)
    {
        _context = context;
    }

    // --------------- READ -----------------
    //Get events
    public async Task<ActionResult<IEnumerable<Member>>> GetMembers()
    {
        var members = _context.Members;

        return await members.ToListAsync();
    }

    //Get member by group with his id
    [HttpGet("{id}")]
    public async Task<ActionResult<IEnumerable<Member>>> GetMemberByGroup(int id)
    {
        var members = await _context.Members
            .Where(s => s.GroupId == id)
            .Include(s => s.Group)
            .Include(s => s.Student)
            .Include(s => s.Role)
            .ToListAsync();

        if (members == null)
            return NotFound();

        return members;
    }


    // --------------- CREATE -----------------
    [HttpPost]
    public async Task<ActionResult<Member>> CreateMember(MemberDTO memberDTO)
    {

        Member _member = new Member(memberDTO);
        var group = _context.Groups.Find(_member.GroupId);
        _member.Group = group!;
        var student = _context.Students.Find(_member.StudentId);
        _member.Student = student!;
        var role = _context.Roles.Find(_member.RoleId);
        _member.Role = role!;
        _context.Members.Add(_member);

        if (group == null || student == null || role == null)
        {
            return BadRequest();
        }

        group.NbMembers++;
        _context.Groups.Update(group);

        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(CreateMember), new { groupId = _member.GroupId, studentId = _member.StudentId }, _member);
    }
}