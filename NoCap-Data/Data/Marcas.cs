using System.ComponentModel.DataAnnotations;

namespace NoCap_Data.Data;

public class Marcas
{
    [Key]
    public int MarcaId { get; set; }
    public string Nombre { get; set; }
    public bool Activo { get; set; } = true;

}
