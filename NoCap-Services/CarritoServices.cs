using Microsoft.EntityFrameworkCore;
using NoCap_Abstracions;
using NoCap_Data.Context;
using NoCap_Data.Data;

namespace NoCap_Services;

public class CarritoServices(IDbContextFactory<NoCapContext> context) : ICarritoServices
{
    public async Task<bool> Guardar(CarritoDto carritoDto)
    {
       if(await Existe(carritoDto) && await IsComprado(carritoDto))
        {
            return await ActulizarCarrito(carritoDto);
        }
        else
        {
            return await Insertar(carritoDto);
        }
    }

    private async Task<bool> Insertar(CarritoDto carritoDto)
    {
        using var Context = await context.CreateDbContextAsync();
        await Context.Carritos.AddAsync(new Carritos
        {
            UsuarioId = carritoDto.UsuarioId,
            FechaCreacion = carritoDto.FechaCreacion,
            MontoTotal = carritoDto.CarritoDetalles.Sum(x => x.Cantidad * x.PrecioProducto),
            EstadoId = 2,
            CarritoDetalles = carritoDto.CarritoDetalles.Select(cd => new CarritoDetalle
            {
                CarritoDetalleId = cd.CarritoDetalleId,
                CarritoId = cd.CarritoId,
                ProductoId = cd.ProductoId,
                Cantidad = cd.Cantidad,
                Talla = cd.Talla,
                Color = cd.Color,
                PrecioProducto = cd.PrecioProducto

            }).ToList()
        });

        return await Context.SaveChangesAsync() > 0;
    }

    private async Task<bool> ActulizarCarrito(CarritoDto carritoDto)
    {
        using var Context = await context.CreateDbContextAsync();

        var carrito = new Carritos
        {
            CarritoId = carritoDto.CarritoId,
            UsuarioId = carritoDto.UsuarioId,
            FechaCreacion = carritoDto.FechaCreacion,
            MontoTotal = carritoDto.CarritoDetalles.Sum(x => x.Cantidad * x.PrecioProducto),
            EstadoId = 2,
            CarritoDetalles = carritoDto.CarritoDetalles.Select(cd => new CarritoDetalle
            {
                CarritoDetalleId = cd.CarritoDetalleId,
                CarritoId = cd.CarritoId,
                ProductoId = cd.ProductoId,
                Cantidad = cd.Cantidad,
                Talla = cd.Talla,
                Color = cd.Color,
                PrecioProducto = cd.PrecioProducto
            }).ToList()
        };

        Context.Carritos.Update(carrito);
        return await Context.SaveChangesAsync() > 0;

    }

    private async Task<bool> Existe(CarritoDto carritoDto)
    {
       using var Context = await context.CreateDbContextAsync();
        return await Context.Carritos
            .AnyAsync(C => C.CarritoId == carritoDto.CarritoId);
    }

    private async Task<bool> IsComprado(CarritoDto carritoDto)
    {
        using var Context = await context.CreateDbContextAsync();
        return await Context.Carritos
            .AnyAsync(C => C.CarritoId == carritoDto.CarritoId && C.EstadoId != 7);
    }

    public async Task<bool> ComprarCarrito(int Carritoid)
    {
        await using var Context = await context.CreateDbContextAsync();
        AfectarInventario(Carritoid);
        return await ActualizarEstado(7, Carritoid);

    }

    public async Task<CarritoDto?> obtenerCarrito(int usuarioId)
    {
        await using var Context = await context.CreateDbContextAsync();
       var Carrito = await Context.Carritos
            .Include(C => C.CarritoDetalles)
            .FirstOrDefaultAsync(c => c.UsuarioId == usuarioId && c.EstadoId != 7);

        var carritodto = new CarritoDto
        {
            CarritoId = Carrito.CarritoId,
            FechaCreacion = Carrito.FechaCreacion,
            UsuarioId = Carrito.UsuarioId,
            MontoTotal = Carrito.MontoTotal,
            EstadoId = Carrito.EstadoId,
            CarritoDetalles = Carrito.CarritoDetalles.Select(cd => new CarritoDetalleDTO
            {
                CarritoDetalleId = cd.CarritoDetalleId,
                CarritoId = cd.CarritoId,
                ProductoId = cd.ProductoId,
                Cantidad = cd.Cantidad,
                Talla = cd.Talla,
                Color = cd.Color,
                PrecioProducto = cd.PrecioProducto

            }).ToList()
        };

        return carritodto;
    }

    private void AfectarInventario(int carritoid)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> ActualizarEstado(int newEstado, int carritoId)
    {
       await using var Context = await context.CreateDbContextAsync();
        var carrito = await Context.Carritos
            .FirstOrDefaultAsync(c => c.CarritoId == carritoId) ?? throw new KeyNotFoundException("No Existe ese carrito");
        carrito.EstadoId = newEstado;
        Context.Carritos.Update(carrito);
        return await Context.SaveChangesAsync() > 0;
    }

}
