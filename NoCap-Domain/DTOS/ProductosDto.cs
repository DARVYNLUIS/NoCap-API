namespace NoCap_Data.Data;

public class ProductosDto 
{
    public int ProductoId { get; set; }
    public string ProductoNombre { get; set; } = string.Empty;
    public string ProductoDescripcion { get; set; } = string.Empty;
    public string ProductoImagne { get; set; } = string.Empty;
    public DateTime FechaCreacionProducto { get; set; } = DateTime.Now;
    public int Stocks { get; set; }
    public double PrecioProductoCompra { get; set; }
    public double PrecioProductoVenta { get; set; }
    public int CategoriaId { get; set; }
    public int MarcaId { get; set; }
}