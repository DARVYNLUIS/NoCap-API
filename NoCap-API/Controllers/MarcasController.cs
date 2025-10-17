using Microsoft.AspNetCore.Mvc;
using NoCap_Data.Data;
using NoCap_Services;

namespace NoCap_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarcasController
        (
        IMarcaServices marcaService
        ) : ControllerBase
    {
        [HttpGet("Lista")]
        public async Task<ActionResult<List<MarcasDto>>> ListarMarcas()
        {
            var marcas = await marcaService.ListMarcas(m => true);
            return Ok(marcas);
        }

        [HttpGet("BuscarPorId/{id}")]
        public async Task<ActionResult<MarcasDto>> GetMarcaById(int id)
        {
            try
            {
                var marca = await marcaService.GetMarcaById(id);
                return Ok(marca);
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

        [HttpPost("Agregar")]
        public async Task<ActionResult<Marcas>> PostMarca(MarcasDto marcas)
        {
            if (await marcaService.Guardar(marcas))
            {
                return Ok(new { mensaje = "Marca creada correctamente" });
            }
            return BadRequest("Error al crear la marca, ");
        }

        [HttpPut("Editar/{id}")]
        public async Task<IActionResult> PutMarca(int id, MarcasDto marcasDto)
        {
            if (id != marcasDto.MarcaId)
            {
                return BadRequest("El ID de la marca no coincide");
            }
            return await marcaService.Guardar(marcasDto) ? NoContent() : NotFound();
        }

        [HttpDelete("Eliminar/{id}")]
        public async Task<IActionResult> DeleteMarca(int id)
        {
            if (!await marcaService.Existe(id))
            {
                return NotFound("No se encontro la marca");
            }
            return await marcaService.DeleteMarca(id) ? NoContent() : BadRequest("No se pudo eliminar la marca");
        }
    }
}
