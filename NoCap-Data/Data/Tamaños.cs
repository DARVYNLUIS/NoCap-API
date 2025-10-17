using System.ComponentModel.DataAnnotations;

namespace NoCap_Data.Data;

public class Tamaños
{
    [Key]
    public int TamañoId { get; set; }
    public string nombre { get; set; }
}
