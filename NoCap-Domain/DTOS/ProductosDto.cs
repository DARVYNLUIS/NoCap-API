namespace NoCap_Data.Data;

public class ProductosDto 
{
    public int ProductoId { get; set; }
    public string ProductoNombre { get; set; } = string.Empty;
    public string ProductoDescripcion { get; set; } = string.Empty;
    public string ProductoImagne { get; set; } = string.Empty;
    public string FechaCreacionProducto { get; set; } 
    public bool Activo { get; set; }
    public int Stocks { get; set; }
    public double PrecioProductoVenta { get; set; }
    public int CategoriaId { get; set; }
    public int MarcaId { get; set; }
    public List<string> Colores { get; set; } = new List<string>();
    public List<string> Tamaños { get; set; } = new List<string>();


}