namespace NoCap_Data.Data;

public class PagosDto
{
    public int PagoId { get; set; }
    public int OrdenCompraId { get; set; }
    public int UsuarioId { get; set; }
    public double MontoPagado { get; set; }
    public DateTime FechaPago { get; set; } = DateTime.Now;
    public bool Pagado { get; set; } = false;
}
