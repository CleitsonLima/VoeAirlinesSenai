using Microsoft.AspNetCore.Mvc;
using VoeAirlinesSenai.Services;
using VoeAirlinesSenai.ViewModels;

namespace VoeAirlinesSenai.Controller;

[Route("api/Piloto")]
[ApiController]
public class PilotoController : ControllerBase
{

    private readonly PilotoService _pilotoService;
    public PilotoController(PilotoService pilotoService)
    {
        _pilotoService = pilotoService;
    }

    [HttpPost]
    public IActionResult AdicionarPiloto(AdicionarPilotoViewModel dados)
    {
        var piloto = _pilotoService.AdicionarPiloto(dados);
        return Ok(piloto);
    }

    [HttpPut("{id}")]
    public IActionResult AtulizarPiloto(int id, AtualizarPilotoViewModel dados)
    {
        if (id != dados.Id)
        {
            return BadRequest("O id informado na URL e diferente do id informado no corpo da requisicao");
        }
        var piloto = _pilotoService.AtualizarPiloto(dados);
        return Ok(piloto);
    }

    [HttpGet]
    public IActionResult ListarPiloto()
    {
        return Ok(_pilotoService.ListarPiloto());
    }

    [HttpGet("{id}")]
    public IActionResult ListarPilotoPeloId(int id)
    {
        var piloto = _pilotoService.ListarPilotoPeloId(id);
        if (piloto != null)
        {
            return Ok(piloto);
        }
        return NotFound();
    }

    [HttpDelete("{id}")]
    public IActionResult DeletarPiloto(int id)
    {
        _pilotoService.DeletarPiloto(id);
        return NoContent();
    }
}