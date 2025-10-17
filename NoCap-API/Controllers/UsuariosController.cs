using Microsoft.AspNetCore.Mvc;
using NoCap_Abstracions;
using NoCap_Data.Data;
using NoCap_Domain.DTOS;

namespace NoCap_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsuariosController(
    IUsuarioServices usuarioServices
    ) : ControllerBase
{
    [HttpPost("IniciarSesion")]
    public async Task<ActionResult<UsuarioDto>> IniciarSesion(RequestLogin login)
    {
        var usuario = await usuarioServices.IniciarSesion(login);
        if (usuario == null)
        {
            return NotFound("Usuario no encontrado");
        }
        else
        {
            return Ok(usuario);
        }
    }

    [HttpPost("CrearUsuario")]
    public async Task<ActionResult> CrearUsuario(UsuarioDto usuarioDto)
    {
        if (await usuarioServices.CrearUsuario(usuarioDto))
        {
            return Ok(new { mensaje = "Usuario creado correctamente" });
        }
        return BadRequest("Error al crear el usuario, ");
    }

    [HttpPut("Actualizar/{id}")]
    public async Task<IActionResult> ActualizarUsuario(int id, UsuarioDto usuarioDto)
    {
        if (id != usuarioDto.UsuarioId)
        {
            return BadRequest("El ID del usuario no coincide");
        }
        return await usuarioServices.ActualizarUsuario(usuarioDto) ? NoContent() : NotFound();
    }

    [HttpDelete("Eliminar/{id}")]
    public async Task<IActionResult> EliminarUsuario(int id)
    {
        return await usuarioServices.EliminarUsuario(id) ? NoContent() : NotFound();
    }
}

