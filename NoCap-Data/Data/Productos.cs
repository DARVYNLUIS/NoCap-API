using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NoCap_Data.Data;

public class Productos
{
    [Key]
    public int ProductoId { get; set; }
    public string ProductoNombre { get; set; }  = string.Empty;
    public string ProductoDescripcion { get; set; } = string.Empty;
    public string? ProductoImagne { get; set; } = string.Empty;
    public DateTime FechaCreacionProducto { get; set; } = DateTime.Now;
    public double PrecioVentaProducto { get; set; }
    public double PrecioCompraProducto { get; set; }

    //Llaves Foraneas
    public int CategoriaId { get; set; }
    [ForeignKey("CategoriaId")]
    public Categorias Categorias { get; set; }
    public int MarcaId { get; set; }
    [ForeignKey("MarcaId")]
    public Marcas Marcas { get; set; }
}
