using System.ComponentModel.DataAnnotations;
namespace ENSC.Models;

public class Event
{
    public int Id { get; set; }
    public int GroupId { get; set; }
    public Group Group { get; set; } = null!;

    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    public DateTime Date { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;

    public Event() { }

    public Event(EventDTO dto)
    {
        //Id = dto.Id;
        GroupId = dto.GroupId;
        Date = dto.Date;
        Name = dto.Name;
        Description = dto.Description;
    }
}