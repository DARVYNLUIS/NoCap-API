namespace NoCap_Data.Data;

public class InventarioDetalleDTO
{
    public int InventarioDetalleId { get; set; }
    public int InventarioId { get; set; }
    public int ProductoId { get; set; }
    public int Cantidad { get; set; }
    public int TamañoId { get; set; }
    public int ColorId { get; set; }
}
