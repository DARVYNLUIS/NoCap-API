using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NoCap_Data.Data;

public class Usuarios
{
    [Key]
    public int UsuarioId { get; set; }
    public string Nombres { get; set; } = string.Empty;
    public string Correo { get; set; } = string.Empty;  
    public string Contraseña { get; set; } = string.Empty;

    [ForeignKey("RolId")]
    public int RolId { get; set; }
    public Roles Rol { get; set; }
}
