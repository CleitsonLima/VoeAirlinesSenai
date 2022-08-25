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


    public AeronaveService(VoeAirLinesSenaiContext context)
    {

        _context = context;

    }

    public DetalhesAeronaveViewModel AdicionarAeronave(AdicionarAeronaveViewModel dados)
    {

        var aeronave = new Aeronave(dados.Fabricante, dados.Modelo, dados.Codigo);
        _context.Add(aeronave);
        _context.SaveChanges();

        return new DetalhesAeronaveViewModel(
            aeronave.Id,
            aeronave.Fabricante,
            aeronave.Codigo,
            aeronave.Modelo
            
        );
    }

    public DetalhesAeronaveViewModel AtualizarAeronave(AtualizarAeronaveViewModel dados)
    {
        var aeronave = new Aeronave(dados.Fabricante,dados.Codigo, dados.Modelo);
        aeronave.Id = dados.Id;
        _context.Update(aeronave);
        _context.SaveChanges();
        return new DetalhesAeronaveViewModel(
            aeronave.Id,
            aeronave.Fabricante,
            aeronave.Codigo,
            aeronave.Modelo);
    }


    public IEnumerable <ListarAeronaveViewModel> ListarAeronaves(){

        return _context.Aeronaves.Select(a=>new ListarAeronaveViewModel(a.Id,a.Codigo,a.Modelo));
    }

    public DetalhesAeronaveViewModel? ListarAeronavePeloId(int id){
        var aeronave = _context.Aeronaves.Find(id);
        if(aeronave != null){
            return new DetalhesAeronaveViewModel(
                aeronave.Id,
                aeronave.Fabricante,
                aeronave.Codigo,
                aeronave.Modelo
            );
        }return null;
    }


    //     public DetalhesAeronaveViewModel DeletarAeronave(int id){
    //     var aeronave = new Aeronave();
    //     aeronave.Id = dados.Id;
    //     _context.Remove(aeronave);
    //     _context.SaveChanges();
    //     return new DetalhesAeronaveViewModel(
    //         aeronave.Id,
    //         aeronave.Fabricante,
    //         aeronave.Modelo,
    //         aeronave.Codigo);
    // }
}