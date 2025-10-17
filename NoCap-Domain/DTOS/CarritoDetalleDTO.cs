namespace NoCap_Data.Data;

public class CarritoDetalleDTO
{
    public int CarritoDetalleId { get; set; }
    public int CarritoId { get; set; }
    public int? ProductoId { get; set; }
    public int Cantidad { get; set; }
    public double PrecioProducto { get; set; }
    public int? ColorId { get; set; }
    public int? TamañoId { get; set; }
}