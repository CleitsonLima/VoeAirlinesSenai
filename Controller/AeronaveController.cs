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

    [HttpPut]
    public IActionResult AtualizarAeronave(AtualizarAeronaveViewModel dados)
    {
        var aeronave = _aeronaveService.AtualizarAeronave(dados);
        return Ok(aeronave);
    }

    // [HttpDelete("{id:int}")]
    // public IActionResult DeletarAeronave(int id)
    // {
    //     var aeronave = _aeronaveService.DeletarAeronave(id);
    //                 if (employeeToDelete == null)
    //         {
    //             return NotFound($"Employee with Id = {id} not found");
    //         }

    //         return  (id);
    //     // return Ok(aeronave);
    // }

}