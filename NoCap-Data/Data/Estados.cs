using System.ComponentModel.DataAnnotations;

namespace NoCap_Data.Data;
public class Estados
{
    [Key]
    public int EstadoId { get; set; }
    public string Nombre { get; set; }
}
