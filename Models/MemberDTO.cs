namespace ENSC.Models;

public class MemberDTO
{
    public int Id { get; set; }
    public int StudentId { get; set; }
    public int RoleId { get; set; } 
    public int GroupId { get; set; } = 0;
}