namespace NoCap_Data.Data;

public class CarritoDto
{
    public int CarritoId { get; set; }
    public int UsuarioId { get; set; }
    public string FechaCreacion { get; set; }
    public double MontoTotal { get; set; }

    public int EstadoId { get; set; }

    public ICollection<CarritoDetalleDTO> CarritoDetalles { get; set; } = [];

}