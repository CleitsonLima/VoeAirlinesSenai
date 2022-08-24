using Microsoft.AspNetCore.Mvc;
using VoeAirlinesSenai.Services;
using VoeAirlinesSenai.ViewModels;

namespace VoeAirlinesSenai.Controller;

[Route("api/aeronaves")]
[ApiController]
public class AeronaveController : ControllerBase
{

    private readonly AeronaveService _aeronaveService;
    public AeronaveController(AeronaveService aeronaveService)
    {

        _aeronaveService = aeronaveService;
    }
    [HttpPost]
    public IActionResult AdicionarAeronave(AdicionarAeronaveViewModel dados)
    {

        var aeronave = _aeronaveService.AdicionarAeronave(dados);
        return Ok(aeronave);

    }
}