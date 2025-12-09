using Microsoft.EntityFrameworkCore;
using NoCap_Abstracions;
using NoCap_Data.Context;
using NoCap_Data.Data;
using System.Linq.Expressions;

namespace NoCap_Services;

public class ProductoServices(IDbContextFactory<NoCapContext> context) : IProductoServices
{

    private async Task<bool> Existe (int productoId)
    {
        using var Context = await context.CreateDbContextAsync();
        return await Context.Productos.AnyAsync(p => p.ProductoId == productoId);
    }

    public async Task<bool> Guardar(ProductosDto productosDto)
    {
        if (await Existe(productosDto.ProductoId))
        {
            return await ActualizarProducto(productosDto);
        }
        else
        {
            return await CrearProducto(productosDto);
        }
    }

    private async Task<bool> ActualizarProducto(ProductosDto productosDto)
    {
        using var Context = context.CreateDbContext();

        var producto = new Productos
        {
            ProductoId = productosDto.ProductoId,
            ProductoNombre = productosDto.ProductoNombre,
            ProductoImagne = productosDto.ProductoImagne,
            PrecioVentaProducto = productosDto.PrecioProductoVenta,
            ProductoDescripcion = productosDto.ProductoDescripcion,
            Stocks = productosDto.Stocks,
            CategoriaId = productosDto.CategoriaId,
            MarcaId = productosDto.MarcaId,
        };

        Context.Productos.Update(producto);
        return await Context.SaveChangesAsync() > 0;
    }

    private async Task<bool> CrearProducto(ProductosDto productosDto)
    {
        using var Context = await context.CreateDbContextAsync();
        await Context.Productos.AddAsync(new Productos
        {
            ProductoNombre = productosDto.ProductoNombre,
            ProductoDescripcion = productosDto.ProductoDescripcion,
            ProductoImagne = productosDto.ProductoImagne,
            Stocks = productosDto.Stocks,
            PrecioVentaProducto = productosDto.PrecioProductoVenta,
            FechaCreacionProducto = productosDto.FechaCreacionProducto,
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
                ProductoImagne = p.ProductoImagne,
                ProductoDescripcion = p.ProductoDescripcion,
                Stocks = p.Stocks,
                PrecioProductoVenta = p.PrecioVentaProducto,
                FechaCreacionProducto = p.FechaCreacionProducto,
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
                ProductoImagne = p.ProductoImagne,
                Stocks = p.Stocks,
                PrecioProductoVenta = p.PrecioVentaProducto,
                FechaCreacionProducto = p.FechaCreacionProducto,
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
