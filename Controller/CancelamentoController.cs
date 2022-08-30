using Microsoft.AspNetCore.Mvc;
using VoeAirlinesSenai.Services;
using VoeAirlinesSenai.ViewModels;

namespace VoeAirlinesSenai.Controller;

[Route("api/cancelamento")]
[ApiController]
public class CancelamentoController : ControllerBase
{

    private readonly CancelamentoService _cancelamentoService;

    public CancelamentoController(CancelamentoService cancelamentoService)
    {
        _cancelamentoService = cancelamentoService;
    }

    [HttpPost]
    public IActionResult AdicionarCancelamento(AdicionarCancelamentoViewModel dados)
    {
        var cancelamento = _cancelamentoService.AdicionarCancelamento(dados);
        return Ok(cancelamento);
    }

    [HttpPut("{id}")]
    public IActionResult AtualizarCancelamento(int id, AtualizarCancelamentoViewModel dados)
    {
        if (id != dados.Id)
        {
            return BadRequest("O id informado na URL é diferente do id informado no corpo da requisição");
        }
        var cancelamento = _cancelamentoService.AtualizarCancelamento(dados);
        return Ok(cancelamento);
    }

    [HttpGet]
    public IActionResult ListarCancelamento()
    {
        return Ok(_cancelamentoService.ListarCancelamento());
    }

    [HttpGet("{id}")]
    public IActionResult ListarCancelamentoPeloId(int id)
    {
        var cancelamento = _cancelamentoService.ListarCancelamentoPeloId(id);
        if (cancelamento != null)
        {
            return Ok(cancelamento);
        }
        return NotFound();
    }

    [HttpDelete("{id}")]
    public IActionResult DeletarCancelamento(int id)
    {
        _cancelamentoService.DeletarCancelamento(id);
        return NoContent();
    }
}