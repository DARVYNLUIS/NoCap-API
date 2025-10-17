using NoCap_Domain.DTOS;
using System.Linq.Expressions;

namespace NoCap_Abstracions;

public interface IColoresServices
{
    Task<List<ColoresDto>> ListColores (Expression<Func<ColoresDto, bool>> expression);
}
