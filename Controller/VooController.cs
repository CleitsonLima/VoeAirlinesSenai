using Microsoft.AspNetCore.Mvc;
using VoeAirlinesSenai.Services;
using VoeAirlinesSenai.ViewModels;

namespace VoeAirlinesSenai.Controller;
[Route("api/voos")]
[ApiController]
public class VooController : ControllerBase
{

    private readonly VooService _vooService;

    public VooController(VooService vooService)
    {
        _vooService = vooService;
    }

    [HttpPost]
    public IActionResult AdicionarVoo(AdicionarVooViewModel dados)
    {
        var voo = _vooService.AdicionarVoo(dados);
        return Ok(voo);
    }

    [HttpPut("{id}")]
    public IActionResult AtualizarVoo(int id, AtualizarVooViewModel dados)
    {
        if (id != dados.Id)
        {
            return BadRequest("O id informado na URL é diferente do id informado no corpo da requisição");
        }
        var voo = _vooService.AtualizarVoo(dados);
        return Ok(voo);
    }

    [HttpGet]
    public IActionResult ListarVoo()
    {
        return Ok(_vooService.ListarVoo());
    }

    [HttpGet("{id}")]
    public IActionResult ListarVooPorId(int id)
    {
        var voo = _vooService.ListarVooPorId(id);
        if (voo != null)
        {
            return Ok(voo);
        }
        return NotFound();
    }

    [HttpDelete("{id}")]
    public IActionResult DeletarVoo(int id)
    {
        _vooService.DeletarVoo(id);
        return NoContent();
    }

    [HttpGet("{id}/ficha")]
    public IActionResult GerarFichaDoVoo(int id)
    {
        var conteudo = _vooService.GerarFichaDoVoo(id);


        if (conteudo != null)
            return File(conteudo, "application/pdf", "relatorio.pdf");

        return NotFound();
    }
}