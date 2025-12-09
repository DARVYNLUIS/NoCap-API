using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NoCap_Data.Data;

public class Carritos
{
    [Key]
    public int CarritoId { get; set; }

    public int UsuarioId { get; set; }

    public string FechaCreacion { get; set; }

    public double MontoTotal { get; set; }

    public int EstadoId { get; set; }


    //LLAVE FORANEA
    [ForeignKey("UsuarioId")]
    public Usuarios Usuario { get; set; }

    [ForeignKey("EstadoId")]
    public Estados Estado { get; set; }

    public ICollection<CarritoDetalle> CarritoDetalles { get; set; } = [];

}
