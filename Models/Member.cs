namespace ENSC.Models;

public class Member
{
    public int Id { get; set; }
    public Student IdStudent { get; set; } = null!;
    public Group IdGroup { get; set; } = null!;

}