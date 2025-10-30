using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NoCap_Data.Data;

public class CarritoDetalle
{
    [Key]
    public int CarritoDetalleId { get; set; }
    public int CarritoId { get; set; }
    public int? ProductoId { get; set; }
    public int Cantidad { get; set; }
    public double PrecioProducto { get; set; }
    public string? Color { get; set; }

    public string? Talla { get; set; }

    //Llaves Foraneas


    [ForeignKey("CarritoId")]
    public Carritos Carritos { get; set; }

    [ForeignKey("ProductoId")]
    public Productos Productos { get; set; }

}
