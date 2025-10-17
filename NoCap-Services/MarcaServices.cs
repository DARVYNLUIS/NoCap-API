using Microsoft.EntityFrameworkCore;
using NoCap_Data.Context;
using NoCap_Data.Data;
using System.Linq.Expressions;

namespace NoCap_Services;

public class MarcaServices(IDbContextFactory<NoCapContext> context) : IMarcaServices
{
    public async Task<bool> DeleteMarca(int id)
    {
        await using var Context = await context.CreateDbContextAsync();

        return await Context.Marcas
            .Where(m => m.MarcaId == id)
            .ExecuteDeleteAsync() > 0;
    }

    public async Task<bool> Existe(int id)
    {
       await using var Context = await context.CreateDbContextAsync();
        return await Context.Marcas
            .AnyAsync(m => m.MarcaId == id);
    }

    public async Task<MarcasDto> GetMarcaById(int id)
    {
       await using var Context = await context.CreateDbContextAsync();
        return await Context.Marcas
            .Where(m => m.MarcaId == id)
            .Select(m => new MarcasDto
            {
                MarcaId = m.MarcaId,
                Nombre = m.Nombre

            }).FirstOrDefaultAsync() ?? throw new KeyNotFoundException("No Existe esa Marca");
    }

    public async Task<bool> Guardar(MarcasDto marcaDto)
    {
        if(await Existe(marcaDto.MarcaId)){
            return await Modificar(marcaDto);
        }else
        {
            return await Insertar(marcaDto);
        }
    }

    private async Task<bool> Insertar(MarcasDto marcaDto)
    {
        await using var Context = await context.CreateDbContextAsync();
        await Context.Marcas.AddAsync(new Marcas
        {
            Nombre = marcaDto.Nombre
        });
        return await Context.SaveChangesAsync() > 0;
    }

    private async Task<bool> Modificar(MarcasDto marcaDto)
    {
        await using var Context = await context.CreateDbContextAsync();
        Context.Marcas.Update(new Marcas
        {
            MarcaId = marcaDto.MarcaId,
            Nombre = marcaDto.Nombre
        });

        return await Context.SaveChangesAsync() > 0;    
    }

    public async Task<List<MarcasDto>> ListMarcas(Expression<Func<MarcasDto, bool>> criterio)
    {
        await using var Context = await context.CreateDbContextAsync();

        return await Context.Marcas
            .Select(m => new MarcasDto
            {
                MarcaId = m.MarcaId,
                Nombre = m.Nombre

            }).Where(criterio)
            .ToListAsync();
    }
}
