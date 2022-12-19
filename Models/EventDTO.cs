using System.ComponentModel.DataAnnotations;
namespace ENSC.Models;

public class EventDTO
{
    public int Id { get; set; }
    public int GroupId { get; set; }
    public DateTime Date { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
}