using System.ComponentModel.DataAnnotations;

namespace NoCap_Data.Data;
public class Categorias
{
    [Key]
    public int CategoriaId { get; set; }
    public string nombre { get; set; }
    public string descripcion { get; set; }
}
