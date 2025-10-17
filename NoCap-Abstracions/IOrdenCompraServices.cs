using NoCap_Data.Data;
using System.Linq.Expressions;

namespace NoCap_Abstracions;

public interface IOrdenCompraServices
{
    Task<bool> Crear(OrdenCompraDTO ordenCompraDto);

    Task<List<OrdenCompraDTO>> ListarOrdenesCompra(Expression<Func<OrdenCompraDTO, bool>> criterio);

    Task<OrdenCompraDTO?> ObtenerPorId(int id);

    Task<bool> ActualizarEstado(int ordenCompraId, int nuevoEstadoId);

}
