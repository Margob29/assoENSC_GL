using System.ComponentModel.DataAnnotations;
namespace ENSC.Models;

public class Role
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
}