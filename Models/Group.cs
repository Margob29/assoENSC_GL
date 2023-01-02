using System.ComponentModel.DataAnnotations;
namespace ENSC.Models;

public class Group
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public ICollection<Member> Students { get; set; }

    [Display(Name = "Nombre de membres")]
    public int? NbMembers { get; set; }
    public List<Event>? Events { get; set; }

    public string Description { get; set; } = null!;

    public Group()
    {
        NbMembers = 0;
    }

    public Group(GroupDTO dto)
    {
        Id = dto.Id;
        Name = dto.Name;
        Description = dto.Description;
        NbMembers = dto.NbMembers;
    }
}