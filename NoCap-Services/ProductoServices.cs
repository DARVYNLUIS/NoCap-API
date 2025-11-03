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
            PrecioVentaProducto = productosDto.PrecioProductoVenta,
            ProductoDescripcion = productosDto.ProductoDescripcion,
            Stocks = productosDto.Stocks,
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
            Stocks = productosDto.Stocks,
            PrecioVentaProducto = productosDto.PrecioProductoVenta,
            CategoriaId = productosDto.CategoriaId,
            MarcaId = productosDto.MarcaId,
            Colores = productosDto.Colores,
            Tamaños = productosDto.Tamaños,
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
                Stocks = p.Stocks,
                PrecioProductoVenta = p.PrecioVentaProducto,
                Activo =p.Activo,
                CategoriaId = p.CategoriaId,
                MarcaId = p.MarcaId,
                Colores = p.Colores,
                Tamaños = p.Tamaños,
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
                Stocks = p.Stocks,
                PrecioProductoVenta = p.PrecioVentaProducto,
                Activo =p.Activo,
                CategoriaId = p.CategoriaId,
                MarcaId = p.MarcaId,
                Colores = p.Colores,
                Tamaños = p.Tamaños,
            })
            .Where(criterio)
            .ToListAsync();
    }
}
