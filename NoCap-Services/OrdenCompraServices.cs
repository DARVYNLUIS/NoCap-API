using Microsoft.EntityFrameworkCore;
using NoCap_Abstracions;
using NoCap_Data.Context;
using NoCap_Data.Data;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;

namespace NoCap_Services;

public class OrdenCompraServices(IDbContextFactory<NoCapContext> context) : IOrdenCompraServices
{
    public async Task<bool> ActualizarEstado(int ordenCompraId, int nuevoEstadoId)
    {
        using var Context = await context.CreateDbContextAsync();

        var ordenCompra = Context.OrdenCompras
                                 .FirstOrDefault( oc => oc.OrdenCompraId == ordenCompraId);

        if (ordenCompra == null) return false;
        ordenCompra.EstadoId = nuevoEstadoId;
        Context.Update(ordenCompra);
        return await Context.SaveChangesAsync() > 0;

    }


    public async Task<bool> Crear(OrdenCompraDTO ordenCompraDto)
    {
        using var Context = await context.CreateDbContextAsync();

        await Context.AddAsync(new OrdenCompra
        {
            OrdenCompraId = ordenCompraDto.OrdenCompraId,
            UsuarioId = ordenCompraDto.UsuarioId,
            CarritoId = ordenCompraDto.CarritoId,
            EstadoId = ordenCompraDto.EstadoId,
            MontoTotaal = ordenCompraDto.MontoTotaal,
            FechaDeCompra = ordenCompraDto.FechaDeCompra
        });

        return await Context.SaveChangesAsync() > 0;

    }

    public async Task<OrdenCompraDTO?> ObtenerPorId(int id)
    {
        using var Contexto = await context.CreateDbContextAsync();
        return await Contexto.OrdenCompras
            .Select( oc => new OrdenCompraDTO
            {
                OrdenCompraId = oc.OrdenCompraId,
                UsuarioId = oc.UsuarioId,
                CarritoId = oc.CarritoId,
                EstadoId = oc.EstadoId,
                MontoTotaal = oc.MontoTotaal,
                FechaDeCompra = oc.FechaDeCompra
            })
            .FirstOrDefaultAsync( oc => oc.OrdenCompraId == id);
    }


    public async Task<List<OrdenCompraDTO>> ListarOrdenesCompra(Expression<Func<OrdenCompraDTO,bool>> criterio)
    {
        using var Context = context.CreateDbContext();

        return await Context.OrdenCompras
            .Select( oc => new OrdenCompraDTO
            {
                OrdenCompraId = oc.OrdenCompraId,
                UsuarioId = oc.UsuarioId,
                CarritoId = oc.CarritoId,
                EstadoId = oc.EstadoId,
                MontoTotaal = oc.MontoTotaal,
                FechaDeCompra = oc.FechaDeCompra
            })
            .Where(criterio)
            .ToListAsync();
    }
}

