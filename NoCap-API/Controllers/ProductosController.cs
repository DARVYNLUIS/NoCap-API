using Microsoft.AspNetCore.Mvc;
using NoCap_Abstracions;
using NoCap_Data.Data;

namespace NoCap_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController(IProductoServices productoServices) : ControllerBase
    {

        [HttpGet("Listar")]
        public async Task<ActionResult<List<ProductosDto>>> ObtenerProductor() 
        {
            var lista = await productoServices.ObtenerTodosLosProductos(P => true);
            return Ok(lista);

        }

        [HttpGet("ObtenerPorId/{id}")]
        public async Task<ActionResult<ProductosDto>> ObtenerPorId(int id)
        {
            try
            { 
                var producto = await productoServices.ObtenerProductoPorId(id);
                return Ok(producto);
            }
            catch (KeyNotFoundException knf)
            {
                return NotFound(knf.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
          
        }

        [HttpPost("Guardar")]
        public async Task<ActionResult> CrearProducto(ProductosDto productosDto)
        {
            if (await productoServices.Guardar(productosDto))
            {
                return Ok(new { mensaje = "Producto creado correctamente" });
            }
            return BadRequest("Error al crear el producto");
        }

      

        [HttpDelete("Eliminar/{id}")]
        public async Task<IActionResult> EliminarProducto(int id)
        {
            return await productoServices.EliminarProducto(id) ? NoContent() : NotFound();
        }

    }
}
