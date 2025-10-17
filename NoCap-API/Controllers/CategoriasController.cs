using Microsoft.AspNetCore.Mvc;
using NoCap_Abstracions;
using NoCap_Data.Data;

namespace NoCap_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriasController
    (
    ICategoriaServices categoriaService
    ): ControllerBase
{
    [HttpGet("Lista")]
    public async Task<ActionResult<List<CategoriasDto>>> ListarCategorias()
    {
        var categorias = await categoriaService.ListCategorias(c => true);
        return Ok(categorias);
    }


    [HttpGet("BuscarPorId/{id}")]
    public async Task<ActionResult<CategoriasDto>> GetCategoriaById(int id)
    {
        try
        {
            var categoria = await categoriaService.GetCategoriaById(id);
            return Ok(categoria);
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
    public async Task<ActionResult<Categorias>> PostCategoria(CategoriasDto categorias)
    {
        if(await categoriaService.Guardar(categorias)){
            return Ok(new { mensaje = "Categoria creada correctamente" });
        }
        return BadRequest("Error al crear la categoria, ");
    }

    [HttpPut("Editar/{id}")]
    public async Task<IActionResult> PutReflexiones (int id, CategoriasDto categoriasDto)
    {
        if (id != categoriasDto.CategoriaId)
        {
            return BadRequest("El ID de la categoria no coincide");
        }

        return await categoriaService.Guardar(categoriasDto) ? NoContent() : NotFound();
    }

    [HttpDelete("Eliminar/{id}")]
    public async Task<IActionResult> DeleteCategoria(int id)
    {
        return await categoriaService.DeleteCategoria(id) ? NoContent() : NotFound();
    }

}
