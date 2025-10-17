using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NoCap_Data.Data;

public class OrdenCompra
{
    [Key]
    public int OrdenCompraId { get; set; }
    public int CarritoId { get; set; }
    public int UsuarioId { get; set; }

    public int MontoTotaal {  get; set; }

    public float Itbis {get; set; } = 0.18f;

    public DateTime FechaDeCompra { get; set; } = DateTime.Now;

    public int EstadoId { get; set; }

    //Llave Foranea
    [ForeignKey("CarritoId")]
    public Carritos Carritos { get; set; }

    [ForeignKey("UsuarioId")]
    public Usuarios Usuarios { get; set; }

    [ForeignKey("EstadoId")]
    public Estados Estados { get; set; }
}
