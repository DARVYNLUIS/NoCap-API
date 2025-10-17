namespace NoCap_Abstracions;

public interface IInventarioServices
{
    Task<bool> ActualizarStockAsync(int productoId, int cantidad);
    Task<bool> RegistrarEntradaAsync(int productoId, int cantidad, int colorId, int tamañoId, int estadoId);
    Task<int> ObtenerStockDisponibleAsync(int productoId);
}
