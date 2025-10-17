using NoCap_Data.Data;
using System.Linq.Expressions;

namespace NoCap_Abstracions;

public interface IProductoServices
{
    Task<bool> CrearProducto(ProductosDto productosDto);
    Task<bool> ActualizarProducto(ProductosDto productosDto);
    Task<bool> EliminarProducto(int id);
    Task<ProductosDto?> ObtenerProductoPorId(int id);
    Task<List<ProductosDto>> ObtenerTodosLosProductos(Expression<Func<ProductosDto,bool>> criterio);
}
