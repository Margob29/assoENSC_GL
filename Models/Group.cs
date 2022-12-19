namespace ENSC.Models;

public class Group
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public int? NbMembers { get; set; }
    public List<Event>? Events { get; set; }
    public Student President { get; set; } = null!;
}