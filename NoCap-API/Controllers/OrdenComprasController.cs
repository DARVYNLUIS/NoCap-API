using Microsoft.AspNetCore.Mvc;
using NoCap_Abstracions;
using NoCap_Data.Data;

namespace NoCap_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrdenComprasController (IOrdenCompraServices ordenCompraServices) : ControllerBase
{
    [HttpGet("Listar")]
   public async Task<IActionResult> ObtenerTodos()
    {
         var ordenes = await ordenCompraServices.ListarOrdenesCompra(oc => true);
         return Ok(ordenes);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> ObtenerPorId(int id)
    {
        var orden = await ordenCompraServices.ObtenerPorId(id);
        if (orden == null) return NotFound();
        return Ok(orden);
    }

    [HttpGet("obtenerPorUsuario/{usuarioId}")]
    public async Task<IActionResult> ObtenerPorUsuario(int usuarioId)
    {
        var ordenes = await ordenCompraServices.ListarOrdenesCompra(oc => oc.UsuarioId == usuarioId);
        return Ok(ordenes);
    }

    [HttpPost("Crear")]
    public async Task<IActionResult> Crear(OrdenCompraDTO ordenCompraDto)
    {
        var resultado = await ordenCompraServices.Crear(ordenCompraDto);
        if (!resultado) return BadRequest("No se pudo crear la orden de compra.");
        return Ok("Orden de compra creada exitosamente.");

    }

    [HttpPut("ActualizarEstado")]
    public async Task<IActionResult> ActualizarEstado(int ordenCompraId, int nuevoEstadoId)
    {
        var resultado = await ordenCompraServices.ActualizarEstado(ordenCompraId, nuevoEstadoId);
        if (!resultado) return BadRequest("No se pudo actualizar el estado de la orden de compra.");
        return Ok("Estado de la orden de compra actualizado exitosamente.");
    }

}
