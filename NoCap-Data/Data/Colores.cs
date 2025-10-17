using System.ComponentModel.DataAnnotations;

namespace NoCap_Data.Data;

public class Colores
{
    [Key]
    public int ColorId { get; set; }
    public string Nombre { get; set; }
}
