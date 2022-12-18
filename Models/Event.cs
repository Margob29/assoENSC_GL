using System.ComponentModel.DataAnnotations;
namespace ENSC.Models;

public class Event
{
    public int Id { get; set; }
    public Group Group { get; set; } = null!;
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    public DateTime Date { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
}