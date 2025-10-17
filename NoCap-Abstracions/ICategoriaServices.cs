using NoCap_Data.Data;
using System.Linq.Expressions;

namespace NoCap_Abstracions;

public interface ICategoriaServices
{
    Task<List<CategoriasDto>> ListCategorias(Expression<Func<CategoriasDto, bool>> criterio );
    Task<CategoriasDto> GetCategoriaById(int id);
    Task<bool> Guardar(CategoriasDto categoriaDto);
    Task<bool> DeleteCategoria(int id);
}
