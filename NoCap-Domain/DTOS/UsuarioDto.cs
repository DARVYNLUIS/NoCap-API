namespace NoCap_Data.Data;

public class UsuarioDto
{
    public int UsuarioId { get; set; }
    public string Nombres { get; set; }
    public string Correo { get; set; }
    public string? Contraseña { get; set; }
    public int RolId { get; set; }
    public string? Token { get; set; }
}
