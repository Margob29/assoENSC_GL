using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ENSC.Models;

public class Student
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? EmailAdress { get; set; }

    public string? Password { get; set; }

    [RegularExpression(@"^\d{4}$")]
    [Range(1900, 9999)]
    public int Promo { get; set; }
    public List<Group>? Groups { get; set; }
    public Group? Group { get; set; }
    public int GroupId { get; set; }
    public int Status { get; set; }
}