using Microsoft.EntityFrameworkCore;
using NoCap_Abstracions;
using NoCap_Data.Context;
using NoCap_Domain.DTOS;
using System.Linq.Expressions;

namespace NoCap_Services;

public class ColoreServices(IDbContextFactory<NoCapContext> context) : IColoresServices
{
    public async Task<List<ColoresDto>> ListColores(Expression<Func<ColoresDto, bool>> expression)
    {
        using var Contexto = await context.CreateDbContextAsync();

        return await Contexto.Colores
            .Select (C => new ColoresDto
            {
                ColorId = C.ColorId,
                Nombre = C.Nombre,

            }).ToListAsync();
    }
}

