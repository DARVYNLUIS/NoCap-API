using NoCap_Domain.DTOS;
using System.Linq.Expressions;

namespace NoCap_Abstracions;

public interface ITamañoServices
{
    Task<List<TamañosDto>> ListTamaño(Expression<Func<TamañosDto, bool>> criterio);
}
