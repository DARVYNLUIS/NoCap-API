using Microsoft.AspNetCore.Mvc;
using NoCap_Abstracions;

namespace NoCap_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class InventariosController(IInventarioServices inventarioServices) : ControllerBase
{
    [HttpPut("actualizar-stock/{productoId}")]
    public async Task<IActionResult> ActualizarStock(int productoId, [FromBody] int cantidad)
    {
        if (productoId <= 0)
            return BadRequest("El ID del producto debe ser mayor a 0");

        var resultado = await inventarioServices.ActualizarStockAsync(productoId, cantidad);

        if (!resultado)
            return NotFound($"No se encontró el producto con ID {productoId} en el inventario");

        return Ok(new { mensaje = "Stock actualizado correctamente", productoId, cantidadModificada = cantidad });
    }

    [HttpPost("registrar-entrada")]
    public async Task<IActionResult> RegistrarEntrada( RegistrarEntradaRequest request)
    {
        if (request.ProductoId <= 0)
            return BadRequest("El ID del producto debe ser mayor a 0");

        if (request.Cantidad <= 0)
            return BadRequest("La cantidad debe ser mayor a 0");

        if (request.ColorId <= 0)
            return BadRequest("El ID del color debe ser mayor a 0");

        if (request.TamañoId <= 0)
            return BadRequest("El ID del tamaño debe ser mayor a 0");

        if (request.EstadoId <= 0)
            return BadRequest("El ID del estado debe ser mayor a 0");

        var resultado = await inventarioServices.RegistrarEntradaAsync(
            request.ProductoId,
            request.Cantidad,
            request.ColorId,
            request.TamañoId,
            request.EstadoId
        );

        if (!resultado)
            return BadRequest("No se pudo registrar la entrada");

        return CreatedAtAction(
            nameof(ObtenerStockDisponible),
            new { productoId = request.ProductoId },
            new { mensaje = "Entrada registrada correctamente", request }
        );
    }

    [HttpGet("stock-disponible/{productoId}")]
    public async Task<IActionResult> ObtenerStockDisponible(int productoId)
    {
        if (productoId <= 0)
            return BadRequest("El ID del producto debe ser mayor a 0");

        var stock = await inventarioServices.ObtenerStockDisponibleAsync(productoId);

        return Ok(new { productoId, stockDisponible = stock });
    }
}