using System.ComponentModel.DataAnnotations;
namespace ENSC.Models;

public class Group
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;

    [Display(Name = "Nombre de membres")]
    public int? NbMembers { get; set; }

    public List<Event>? Events { get; set; }

    [Display(Name = "Président")]
    public Student President { get; set; } = null!; // TODO ça devrait pas être un membre ?

}