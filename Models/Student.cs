namespace ENSC.Models;

public class Student
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? EmailAdress { get; set; }

    public string? Password { get; set; }
    public DateTime Promo { get; set; }
    public List<Group>? Groups { get; set; }
    public int Status { get; set; }

    public override string ToString()
    {
        return Name;
    }
}