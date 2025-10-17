namespace NoCap_API.Controllers;

public class RegistrarEntradaRequest
{
    public int ProductoId { get; set; }
    public int Cantidad { get; set; }
    public int ColorId { get; set; }
    public int TamañoId { get; set; }
    public int EstadoId { get; set; }
}
