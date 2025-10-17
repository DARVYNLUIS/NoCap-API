using System.ComponentModel.DataAnnotations;

namespace NoCap_Data.Data;

public class Roles
{
    [Key]
    public int RolId { get; set; }
    public string NombreRol { get; set; }
    public ICollection<Usuarios> Usuarios { get; set; } = [];
}
