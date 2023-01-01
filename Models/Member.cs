using System.ComponentModel.DataAnnotations;
namespace ENSC.Models;
public class Member
{
    public int StudentId { get; set; }
    public Student Student { get; set; } = null!;

    public int GroupId { get; set; }
    public Group Group { get; set; } = null!;

    // Attribut de la relation
    public int RoleId { get; set; }

    public Role Role { get; set; } = null!;
}
