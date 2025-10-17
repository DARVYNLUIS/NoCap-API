using Microsoft.EntityFrameworkCore;
using NoCap_Data.Context;
using NoCap_Data.Data;
using NoCap_Abstracions;

namespace NoCap_Services;

public class InventarioServices(IDbContextFactory<NoCapContext> contextFactory) : IInventarioServices
{
    public async Task<bool> ActualizarStockAsync(int productoId, int cantidad)
    {
        using var context = await contextFactory.CreateDbContextAsync();

        var detalle = await context.InventarioDetalles
            .FirstOrDefaultAsync(d => d.ProductoId == productoId);

        if (detalle == null)
            return false;

        detalle.Cantidad += cantidad; // puede ser positivo o negativo
        context.InventarioDetalles.Update(detalle);

        // Actualiza total del inventario padre
        var inventario = await context.Inventarios
            .FirstOrDefaultAsync(i => i.InventarioId == detalle.InventarioId);

        if (inventario != null)
        {
            inventario.CantidadProductos = await context.InventarioDetalles
                .Where(d => d.InventarioId == inventario.InventarioId)
                .SumAsync(d => d.Cantidad);
        }

        await context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> RegistrarEntradaAsync(int productoId, int cantidad, int colorId, int tamañoId, int estadoId)
    {
        using var context = await contextFactory.CreateDbContextAsync();

        var inventario = await context.Inventarios.FirstOrDefaultAsync();
        if (inventario == null)
        {
            inventario = new Inventario
            {
                FechaAgregado = DateTime.Now,
                CantidadProductos = 0
            };
            await context.Inventarios.AddAsync(inventario);
            await context.SaveChangesAsync();
        }

        var detalle = new InventarioDetalle
        {
            InventarioId = inventario.InventarioId,
            ProductoId = productoId,
            Cantidad = cantidad,
            ColorId = colorId,
            TamañoId = tamañoId,
            EstadoId = estadoId
        };

        await context.InventarioDetalles.AddAsync(detalle);
        inventario.CantidadProductos += cantidad;

        await context.SaveChangesAsync();
        return true;
    }

    public async Task<int> ObtenerStockDisponibleAsync(int productoId)
    {
        using var context = await contextFactory.CreateDbContextAsync();

        var total = await context.InventarioDetalles
            .Where(d => d.ProductoId == productoId)
            .SumAsync(d => d.Cantidad);

        return total;
    }
}
