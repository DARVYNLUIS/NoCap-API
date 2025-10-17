using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NoCap_Data.Data;
public class InventarioDetalle
{
    [Key]
    public int InventarioDetalleId { get; set; }
    public int InventarioId { get; set; }
    public int ProductoId { get; set; }
    public int Cantidad { get; set; }
    public int TamañoId { get; set; }
    public int ColorId { get; set; }

    public int EstadoId { get; set; }


    //Llaves Foraneas

    [ForeignKey("InventarioId")]
    public Inventario Inventario { get; set; }

    [ForeignKey("ProductoId")]
    public Productos Productos { get; set; }

    [ForeignKey("TamañoId")]
    public Tamaños Tamaños { get; set; }

    [ForeignKey("ColorId")]
    public Colores Colores { get; set; }
    [ForeignKey("EstadoId")]
    public Estados Estados { get; set; }

}
