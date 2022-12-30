namespace ENSC.Models;

public class GroupDTO
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public int NbMembers { get; set; }
    public Student? PresidentId { get; set; }
}