using Microsoft.AspNetCore.Mvc;
using NoCap_Abstracions;
using NoCap_Data.Data;

namespace NoCap_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CarritosController (ICarritoServices carritoServices) : ControllerBase
{
    [HttpGet("ObtenerCarritoUsuario/{id}")]
    public async Task<ActionResult<CarritoDto>> GetCarritoById(int id)
    {
        var carrito = await carritoServices.obtenerCarrito(id);
        if (carrito == null)
        {
            return NotFound();
        }
        return Ok(carrito);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCarrito(CarritoDto carritoDto)
    {
        var createdCarrito = await carritoServices.Guardar(carritoDto);

        if (createdCarrito == false)
        {
            return BadRequest("No se pudo crear el carrito.");
        }
        return Ok("Carrito Creado Correctamente");

    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCarrito(int id, CarritoDto carritoDto)
    {
        var updatedCarrito = await carritoServices.Guardar(carritoDto);
        if (updatedCarrito == null)
        {
            return NotFound();
        }
        return Ok(updatedCarrito);
    }

    [HttpPost("Comprar")]
    public async Task<IActionResult> Comprar(int id)
    {
        var result = await carritoServices.ComprarCarrito(id);
        if (!result)
        {
            return BadRequest("No se pudo completar la compra.");
        }
        return Ok("Compra completada con éxito.");

    }



}