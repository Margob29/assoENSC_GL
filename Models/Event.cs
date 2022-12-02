namespace ENSC;

public class Event
{
    public int Id { get; set; }
    public Group GroupeId { get; set; } = null!;
    public DateTime Date { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
}