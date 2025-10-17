using Microsoft.EntityFrameworkCore;
using NoCap_Abstracions;
using NoCap_Data.Context;
using NoCap_Data.Data;
using System.Linq.Expressions;

namespace NoCap_Services;

public class CategoriaService(IDbContextFactory<NoCapContext> context) : ICategoriaServices
{
    public async Task<bool> Existe(int id)
    {
        await using var Context = await context.CreateDbContextAsync();

        return await Context.Categorias
            .AnyAsync(C => C.CategoriaId == id);
    }

    public async Task<bool> DeleteCategoria(int id)
    {
        await using var Context = await context.CreateDbContextAsync();

        return await Context.Categorias
            .Where(c => c.CategoriaId == id)
            .ExecuteDeleteAsync() > 0;
    }

    public async Task<CategoriasDto> GetCategoriaById(int id)
    {
        await using var Context = await context.CreateDbContextAsync();

        return await Context.Categorias
            .Where(c => c.CategoriaId == id)
            .Select(c => new CategoriasDto
            {
                CategoriaId = c.CategoriaId,
                nombre = c.nombre,
                descripcion = c.descripcion

            }).FirstOrDefaultAsync() ?? throw new KeyNotFoundException("No Existe esa categoria");
    }

    public async Task<bool> Guardar(CategoriasDto categoriaDto)
    {
        if (await Existe(categoriaDto.CategoriaId))
        {
            return await Modificar(categoriaDto);
        }
        else
        {
            return await Insertar(categoriaDto);
        }
    }

    private async Task<bool> Insertar(CategoriasDto categoriasDto)
    {
        await using var Context = await context.CreateDbContextAsync();
        await Context.Categorias.AddAsync(new Categorias
        {
            nombre = categoriasDto.nombre,
            descripcion = categoriasDto.descripcion
        });
        return await Context.SaveChangesAsync() > 0;
    }

    private async Task<bool> Modificar(CategoriasDto categoriasDto)
    {
        await using var Context = await context.CreateDbContextAsync();

        Context.Categorias.Update(new Categorias
        {
            CategoriaId = categoriasDto.CategoriaId,
            nombre = categoriasDto.nombre,
            descripcion = categoriasDto.descripcion

        });

        return await Context.SaveChangesAsync() > 0;
    }

    public async Task<List<CategoriasDto>> ListCategorias(Expression<Func<CategoriasDto, bool>> criterio)
    {
        using var Context = await context.CreateDbContextAsync();
        return await Context.Categorias
            .Select (c => new CategoriasDto
            {
                CategoriaId = c.CategoriaId,
                nombre = c.nombre,
                descripcion = c.descripcion

            }).Where(criterio)
            .ToListAsync();
    }
}
