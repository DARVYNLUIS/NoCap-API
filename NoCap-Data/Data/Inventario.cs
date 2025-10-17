using System.ComponentModel.DataAnnotations;

namespace NoCap_Data.Data;

public class Inventario
{
    [Key]
    public int InventarioId { get; set; }

    public DateTime FechaAgregado {get;set;}

    public int CantidadProductos {  get; set; }

    //Llaves Foraneas
    public ICollection<InventarioDetalle> InventarioDetalles { get; set; } = new List<InventarioDetalle>();

}
