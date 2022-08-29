using Microsoft.AspNetCore.Mvc;
using VoeAirlinesSenai.Services;
using VoeAirlinesSenai.ViewModels;

namespace VoeAirlinesSenai.Controller;


[Route("api/manutencao")]
[ApiController]
public class ManutencaoController : ControllerBase
{

    private readonly ManutencaoService _manutencaoService;
    public ManutencaoController(ManutencaoService manutencaoService)
    {
        _manutencaoService = manutencaoService;
    }

    [HttpPost]
    public IActionResult AdicionarManutencao(AdicionarManutencaoViewModel dados)
    {
        var manutencao = _manutencaoService.AdicionarManutencao(dados);
        return Ok(manutencao);
    }

    [HttpPut("{id}")]
    public IActionResult AtualizarManutencao(int id, AtualizarManutencaoViewModel dados)
    {
        if (id != dados.Id)
        {
            return BadRequest("O id informado na URL é diferente do id informado no corpo da requisição");
        }
        var manutencao = _manutencaoService.AtualizarManutencao(dados);
        return Ok(manutencao);
    }

    [HttpGet]
    public IActionResult ListarManutencao()
    {
        return Ok(_manutencaoService.ListarManutencao());
    }

    [HttpGet("{id}")]
    public IActionResult ListarManutencaoPeloId(int id)
    {
        var manutencao = _manutencaoService.ListarManutencaoPeloId(id);
        if (manutencao != null)
        {
            return Ok(manutencao);
        }
        return NotFound();
    }

    [HttpGet("ListarManutencaoDaAeronave/{aeronaveId}")]
    public IActionResult ListarManutencaoDaAeronave(int aeronaveId){
        var manutencaoaeronave = _manutencaoService.ListarManutencoesDaAeronave(aeronaveId);
          if (manutencaoaeronave != null)
        {
            return Ok(manutencaoaeronave);
        }
        return NotFound();
    }

    [HttpDelete("{id}")]
    public IActionResult DeletarManutencao(int id)
    {
        _manutencaoService.DeletarManutencao(id);
        return NoContent();
    }
}