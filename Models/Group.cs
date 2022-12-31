using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ENSC.Models;

public class Group
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;

    public List<Student> Students { get; set; } = new();


    [Display(Name = "Nombre de membres")]
    public int NbMembers { get; set; } = 0;
    public List<Event>? Events { get; set; }

    public Student President { get; set; } = null!;
    public int PresidentId { get; set; }


    public string Description { get; set; } = null!;

    public Group()
    {
    }

    public Group(GroupDTO dto)
    {
        Id = dto.Id;
        Name = dto.Name;
        Description = dto.Description;
        NbMembers = dto.NbMembers;
        //President = dto.PresidentId;
    }
}