namespace NoCap_Data.Data;

public class OrdenCompraDTO
{
    public int OrdenCompraId { get; set; }
    public int CarritoId { get; set; }
    public int UsuarioId { get; set; }
    public int MontoTotaal { get; set; }
    public float Itbis { get; set; }
    public string FechaDeCompra { get; set; }
    public int EstadoId { get; set; }
}
