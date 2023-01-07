using System.ComponentModel.DataAnnotations;
namespace ENSC.Models;

public class Role
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;

    public Role() { }

    public Role(RoleDTO dto)
    {
        Id = dto.Id;
        Name = dto.Name;
        Description = dto.Description;
    }
}