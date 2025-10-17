using Microsoft.EntityFrameworkCore;
using NoCap_Abstracions;
using NoCap_Data.Context;
using NoCap_Domain.DTOS;
using System.Linq.Expressions;

namespace NoCap_Services;

public class TamañosServices(IDbContextFactory<NoCapContext> context) : ITamañoServices
{
    public async Task<List<TamañosDto>> ListTamaño(Expression<Func<TamañosDto, bool>> criterio)
    {
        using var Context = await context.CreateDbContextAsync();
        return await Context.Tamaños
            .Select( c => new TamañosDto
            {
                TamañoId = c.TamañoId,
                nombre = c.nombre,
            }).Where(criterio)
            .ToListAsync();
    }
}
