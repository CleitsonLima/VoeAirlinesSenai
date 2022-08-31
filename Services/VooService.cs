using VoeAirlinesSenai.Contexts;
using VoeAirlinesSenai.Entities;
using VoeAirlinesSenai.ViewModels;

namespace VoeAirlinesSenai.Services;

public class VooService
{
    private readonly VoeAirLinesSenaiContext _context;

    public VooService(VoeAirLinesSenaiContext context)
    {
        _context = context;
    }

    public DetalhesVooViewModel AdicionarVoo(AdicionarVooViewModel dados)
    {
        var voo = new Voo(dados.Origem, dados.Destino, dados.DataHoraPartida, dados.DataHoraChegada, dados.AeronaveId, dados.PilotoId);
        _context.Add(voo);
        _context.SaveChanges();

        return new DetalhesVooViewModel(voo.Id, voo.Origem, voo.Destino, voo.DataHoraPartida, voo.DataHoraChegada, voo.AeronaveId, voo.PilotoId);
    }

    public DetalhesVooViewModel? AtualizarVoo(AtualizarVooViewModel dados)
    {
        var voo = _context.Voos.Find(dados.Id);
        if (voo != null)
        {
            voo.Origem = dados.Origem;
            voo.Destino = dados.Destino;
            voo.DataHoraPartida = dados.DataHoraPartida;
            voo.DataHoraChegada = dados.DataHoraChegada;
            voo.AeronaveId = dados.AeronaveId;
            voo.PilotoId = dados.PilotoId;
            _context.Update(voo);
            _context.SaveChanges();
            return new DetalhesVooViewModel(voo.Id, voo.Origem, voo.Destino, voo.DataHoraPartida, voo.DataHoraChegada, voo.AeronaveId, voo.PilotoId);
        }
        return null;
    }

    public IEnumerable<ListarVooViewModel> ListarVoo()
    {
        return _context.Voos.Select(voo => new ListarVooViewModel(voo.Id, voo.Origem, voo.Destino, voo.DataHoraPartida, voo.DataHoraChegada, voo.AeronaveId, voo.PilotoId));
    }

    public DetalhesVooViewModel? ListarVooPorId(int id)
    {
        var voo = _context.Voos.Find(id);
        if (voo != null)
        {
            return new DetalhesVooViewModel(voo.Id, voo.Origem, voo.Destino, voo.DataHoraPartida, voo.DataHoraChegada, voo.AeronaveId, voo.PilotoId);
        }
        return null;
    }

    public void DeletarVoo(int id)
    {
        var voo = _context.Voos.Find(id);
        if (voo != null)
        {
            _context.Remove(voo);
            _context.SaveChanges();
        }
    }
}