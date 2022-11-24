namespace ENSC;

public class Group
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public int NbMembers { get; set; }
    public List<Student> Members { get; set; } = null!;
    public List<Event>? Events { get; set; }
    public Student President { get; set; } = null!;
}