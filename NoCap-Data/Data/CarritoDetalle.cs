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
    public int?  ColorId { get; set; }
    public int? TamañoId { get; set; }


    //Llaves Foraneas

    [ForeignKey("ColorId")]
    public Colores Colores { get; set; }

    [ForeignKey("TamañoId")]
    public Tamaños Tamaños { get; set; }

    [ForeignKey("CarritoId")]
    public Carritos Carritos { get; set; }

    [ForeignKey("ProductoId")]
    public Productos Productos { get; set; }

}
