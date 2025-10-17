namespace NoCap_Data.Data;

public class InventarioDto
{
    public int InventarioId { get; set; }
    public DateTime FechaAgregado {get;set; }
    public int CantidadProductos {  get; set; }
    public List<InventarioDetalleDTO> InventarioDetalles { get; set; } = new List<InventarioDetalleDTO>();
}
