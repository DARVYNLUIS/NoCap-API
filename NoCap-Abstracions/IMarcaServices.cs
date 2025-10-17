using NoCap_Data.Data;
using System.Linq.Expressions;

namespace NoCap_Services;

public interface IMarcaServices
{
    Task<bool> DeleteMarca(int id);

    Task<bool> Existe(int id);

    Task<MarcasDto> GetMarcaById(int id);

    Task<bool> Guardar(MarcasDto marcaDto);

    Task<List<MarcasDto>> ListMarcas(Expression<Func<MarcasDto, bool>> criterio);

}