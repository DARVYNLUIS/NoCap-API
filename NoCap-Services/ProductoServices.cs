using Microsoft.EntityFrameworkCore;
using NoCap_Abstracions;
using NoCap_Data.Context;
using NoCap_Data.Data;
using System.Linq.Expressions;

namespace NoCap_Services;

public class ProductoServices(IDbContextFactory<NoCapContext> context) : IProductoServices
{
    public async Task<bool> ActualizarProducto(ProductosDto productosDto)
    {
        using var Context = context.CreateDbContext();

        var producto = new Productos
        {
            ProductoId = productosDto.ProductoId,
            ProductoNombre = productosDto.ProductoNombre,
            PrecioCompraProducto = productosDto.PrecioProductoCompra,
            PrecioVentaProducto = productosDto.PrecioProductoVenta,
            ProductoDescripcion = productosDto.ProductoDescripcion,
            CategoriaId = productosDto.CategoriaId,
            MarcaId = productosDto.MarcaId,
        };

        Context.Productos.Update(producto);
        return await Context.SaveChangesAsync() > 0;
    }

    public async Task<bool> CrearProducto(ProductosDto productosDto)
    {
        using var Context = await context.CreateDbContextAsync();
        await Context.Productos.AddAsync(new Productos
        {
            ProductoNombre = productosDto.ProductoNombre,
            ProductoDescripcion = productosDto.ProductoDescripcion,
            PrecioCompraProducto = productosDto.PrecioProductoCompra,
            PrecioVentaProducto = productosDto.PrecioProductoVenta,
            CategoriaId = productosDto.CategoriaId,
            MarcaId = productosDto.MarcaId,
        });
        return await Context.SaveChangesAsync() > 0;
    }

    public async Task<bool> EliminarProducto(int id)
    {
        using var Context = await context.CreateDbContextAsync();
        return await Context.Productos
            .Where(p => p.ProductoId == id)
            .ExecuteDeleteAsync() > 0;
    }

    public async Task<ProductosDto?> ObtenerProductoPorId(int id)
    {
         using var Context = await context.CreateDbContextAsync();
         return await Context.Productos
            .Where(p => p.ProductoId == id)
            .Select(p => new ProductosDto
            {
                ProductoId = p.ProductoId,
                ProductoNombre = p.ProductoNombre,
                ProductoDescripcion = p.ProductoDescripcion,
                PrecioProductoCompra = p.PrecioCompraProducto,
                PrecioProductoVenta = p.PrecioVentaProducto,
                CategoriaId = p.CategoriaId,
                MarcaId = p.MarcaId,
            })
            .FirstOrDefaultAsync() ?? throw new KeyNotFoundException("No se ha encuentra esa categoria"); 
    }

    public async Task<List<ProductosDto>> ObtenerTodosLosProductos(Expression<Func<ProductosDto, bool>> criterio)
    {
        using var Context = await context.CreateDbContextAsync();
        return await Context.Productos
            .Select(p => new ProductosDto
            {
                ProductoId = p.ProductoId,
                ProductoNombre = p.ProductoNombre,
                ProductoDescripcion = p.ProductoDescripcion,
                PrecioProductoCompra = p.PrecioCompraProducto,
                PrecioProductoVenta = p.PrecioVentaProducto,
                CategoriaId = p.CategoriaId,
                MarcaId = p.MarcaId,
            })
            .Where(criterio)
            .ToListAsync();
    }
}
