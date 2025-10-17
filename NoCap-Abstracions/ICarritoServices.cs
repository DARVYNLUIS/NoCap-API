using NoCap_Data.Data;
using System.Linq.Expressions;

namespace NoCap_Abstracions;

public interface ICarritoServices
{
    public Task<bool> Guardar(CarritoDto carritoDto);

    public Task<bool> ActualizarEstado(int newEstado, int carritoId);

    public Task<bool> ComprarCarrito(int Carritoid);

    public Task<CarritoDto?> obtenerCarrito(int usuarioId);

}
