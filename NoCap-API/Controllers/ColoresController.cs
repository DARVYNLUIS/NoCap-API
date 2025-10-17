using Microsoft.AspNetCore.Mvc;
using NoCap_Abstracions;
using NoCap_Domain.DTOS;

namespace NoCap_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ColoresController
    (
      IColoresServices coloresServices
    ): ControllerBase
{
    [HttpGet("Lista")]
    public async Task<ActionResult<List<ColoresDto>>> ListColores()
    {
        var Colores = await coloresServices.ListColores(C => true);
        return Ok(Colores);
    }
 
}
