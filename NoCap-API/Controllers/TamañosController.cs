using Microsoft.AspNetCore.Mvc;
using NoCap_Abstracions;
using NoCap_Domain.DTOS;

namespace NoCap_API.Controllers; 

[Route("api/[controller]")]
[ApiController]
public class TamañosController
    (
     ITamañoServices tamañoServices
    ) : ControllerBase
{
    [HttpGet("Listar")]
    public async Task<ActionResult<List<TamañosDto>>> ListarTamaños()
    {
        var tamaños = await tamañoServices.ListTamaño(t => true);
        return Ok(tamaños);
    }
}
