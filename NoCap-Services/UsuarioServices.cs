using Microsoft.EntityFrameworkCore;
using NoCap_Abstracions;
using NoCap_Data.Context;
using NoCap_Data.Data;
using NoCap_Domain.DTOS;

namespace NoCap_Services;

public class UsuarioServices(IDbContextFactory<NoCapContext> context) : IUsuarioServices
{
    public async Task<bool> ActualizarUsuario(UsuarioDto usuarioDto)
    {
        using var Contexto = await context.CreateDbContextAsync();

        var usuario = await Contexto.Usuarios
             .FirstOrDefaultAsync(u => u.UsuarioId == usuarioDto.UsuarioId);

        if (usuario == null) return false;

        usuario.Nombres = usuarioDto.Nombres;
        usuario.Correo = usuarioDto.Correo;
        Contexto.Usuarios.Update(usuario);

        return await Contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> CrearUsuario(UsuarioDto usuarioDto)
    {
        using var Contexto = await context.CreateDbContextAsync();

        await Contexto.AddAsync(new Usuarios
        {
            UsuarioId = usuarioDto.UsuarioId,
            Nombres = usuarioDto.Nombres,
            Correo = usuarioDto.Correo,
            Contraseña = usuarioDto.Contraseña,
            RolId = 2,
        });
        return await Contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> EliminarUsuario(int id)
    {
        using var Contexto = await context.CreateDbContextAsync();

        return await Contexto.Usuarios
            .Where(u => u.UsuarioId == id)
            .ExecuteDeleteAsync() > 0;
    }

    public async Task<UsuarioDto?> IniciarSesion(RequestLogin requestLogin)
    {
        using var Context = await context.CreateDbContextAsync();
        return await Context.Usuarios
            .Where(U => U.Correo == requestLogin.Email && U.Contraseña == requestLogin.Password)
            .Select(U => new UsuarioDto
            {
                UsuarioId = U.UsuarioId,
                Nombres = U.Nombres,
                Correo = U.Correo,
                RolId = U.RolId
            })
           .FirstOrDefaultAsync();
    }
}
