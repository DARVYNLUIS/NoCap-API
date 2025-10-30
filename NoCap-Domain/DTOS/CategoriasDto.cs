namespace NoCap_Data.Data;

public class CategoriasDto
{
    public int CategoriaId { get; set; }
    public string nombre { get; set; }
    public string descripcion { get; set; }
    public bool Activo { get; set; } = true;

}