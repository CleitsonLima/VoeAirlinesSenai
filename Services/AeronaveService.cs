using VoeAirlinesSenai.Contexts;
using VoeAirlinesSenai.Entities;
using VoeAirlinesSenai.ViewModels;

namespace VoeAirlinesSenai.Services;



//classe de servico- trabalhar com funcionalidade do sistema
public class AeronaveService
{
    //RF - Requisito funcional
    //RF - Nao funcionais
    // Nesse momento sera usado com requisitos funcionais

    private readonly VoeAirLinesSenaiContext _context;


    public AeronaveService(VoeAirLinesSenaiContext context){

        _context = context;
        
    }

    public DetalhesAeronaveViewModel AdicionarAeronave(AdicionarAeronaveViewModel dados){

        var aeronave = new Aeronave(dados.Fabricante,dados.Modelo,dados.Codigo);
        _context.Add(aeronave);
        _context.SaveChanges();

        return new DetalhesAeronaveViewModel(
            aeronave.Id,
            aeronave.Fabricante,
            aeronave.Modelo,
            aeronave.Codigo
        );
    }
}