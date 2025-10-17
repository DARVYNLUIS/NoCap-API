using NoCap_Data.Data;
using NoCap_Domain.DTOS;

namespace NoCap_Abstracions;
public interface IUsuarioServices
{
    Task<UsuarioDto?> IniciarSesion(RequestLogin requestLogin);

    Task<bool> CrearUsuario(UsuarioDto usuarioDto);

    Task<bool> EliminarUsuario(int id);

    Task<bool> ActualizarUsuario(UsuarioDto usuarioDto);
}
