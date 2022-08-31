using VoeAirlinesSenai.Contexts;
using VoeAirlinesSenai.Entities;
using VoeAirlinesSenai.ViewModels;

namespace VoeAirlinesSenai.Services;

public class PilotoService
{
    private readonly VoeAirLinesSenaiContext _context;

    public PilotoService(VoeAirLinesSenaiContext context)
    {

        _context = context;

    }

    public DetalhesPilotoViewModel AdicionarPiloto(AdicionarPilotoViewModel dados)
    {
        var piloto = new Piloto(dados.Nome, dados.Matricula);
        _context.Add(piloto);
        _context.SaveChanges();

        return new DetalhesPilotoViewModel(piloto.Id, piloto.Nome, piloto.Matricula);
    }
    public DetalhesPilotoViewModel? AtualizarPiloto(AtualizarPilotoViewModel dados)
    {
        var piloto = _context.pilotos.Find(dados.Id); ;
        if (piloto != null)
        {
            piloto.Nome = dados.Nome;
            piloto.Matricula = dados.Matricula;
            _context.Update(piloto);
            _context.SaveChanges();

            return new DetalhesPilotoViewModel(piloto.Id, piloto.Nome, piloto.Matricula);
        }
        return null;
    }
    public IEnumerable<ListarPilotoViewModel> ListarPiloto()
    {

        return _context.pilotos.Select(a => new ListarPilotoViewModel(a.Id,a.Nome,a.Matricula));
    }

    public DetalhesPilotoViewModel? ListarPilotoPeloId(int id)
    {
        var piloto = _context.pilotos.Find(id);
        if (piloto != null)
        {
            return new DetalhesPilotoViewModel(piloto.Id,piloto.Nome,piloto.Matricula);
        }
        return null;
    }

    public void DeletarPiloto(int id)
    {
        var piloto = _context.pilotos.Find(id);
        if (piloto != null)
        {
            _context.Remove(piloto);
            _context.SaveChanges();
        }
    }
}