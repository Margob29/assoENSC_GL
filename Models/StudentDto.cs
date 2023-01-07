namespace ENSC.Models;

public class StudentDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string EmailAdress { get; set; } = null!;
    public int Promo { get; set; }
}