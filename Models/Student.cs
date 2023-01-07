using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ENSC.Models;

public class Student
{
    public int Id { get; set; }


    [Display(Name = "Nom")]
    public string Name { get; set; } = null!;

    [Display(Name = "Email")]
    [DataType(DataType.EmailAddress)]
    public string EmailAdress { get; set; } = null!;

    public string? Password { get; set; }


    [Display(Name = "Année du diplome")]
    [RegularExpression(@"^\d{4}$")]
    [Range(1900, 9999)]
    public int Promo { get; set; }
    public ICollection<Member>? Groups { get; set; }
    public Group? Group { get; set; }
    //public int GroupId { get; set; }

    public Student()
    {

    }

    public Student(StudentDto dto)
    {
        Id = dto.Id;
        Name = dto.Name;
        EmailAdress = dto.EmailAdress;
        Promo = dto.Promo;
    }
}