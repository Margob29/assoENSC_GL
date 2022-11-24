namespace ENSC;

public class Event
{
    public int Id { get; set; }
    public int GroupeId { get; set; }
    public DateTime Date { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public bool Visibility { get; set; }
}