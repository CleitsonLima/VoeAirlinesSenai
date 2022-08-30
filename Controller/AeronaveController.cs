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

    [HttpPut("{id}")]
    public IActionResult AtualizarAeronave(int id, AtualizarAeronaveViewModel dados)
    {
        if (id != dados.Id)
        {
            return BadRequest("O id informado na URL é diferente do id informado no corpo da requisição");
        }
        var aeronave = _aeronaveService.AtualizarAeronave(dados);
        return Ok(aeronave);
    }

    [HttpGet]
    public IActionResult ListarAeronaves()
    {
        return Ok(_aeronaveService.ListarAeronaves());
    }

    [HttpGet("{id}")]
    public IActionResult ListarAeronavesPeloId(int id)
    {
        var aeronave = _aeronaveService.ListarAeronavePeloId(id);
        if (aeronave != null)
        {
            return Ok(aeronave);
        }
        return NotFound();
    }

    [HttpDelete("{id}")]
    public IActionResult DeletarAeronave(int id)
    {
        _aeronaveService.DeletarAeronave(id);
        return NoContent();
    }
}