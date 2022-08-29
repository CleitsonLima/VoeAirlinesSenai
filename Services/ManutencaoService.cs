using VoeAirlinesSenai.Contexts;
using VoeAirlinesSenai.Entities;
using VoeAirlinesSenai.ViewModels;

namespace VoeAirlinesSenai.Services;

public class ManutencaoService
{


    private readonly VoeAirLinesSenaiContext _context;


    public ManutencaoService(VoeAirLinesSenaiContext context)
    {

        _context = context;

    }

    public DetalhesManutencaoViewModel AdicionarManutencao(AdicionarManutencaoViewModel dados)
    {
        var manutencao = new Manutencao(dados.DataHora, dados.Tipo, dados.AeronaveId, dados.Observacoes);
        _context.Add(manutencao);
        _context.SaveChanges();

        return new DetalhesManutencaoViewModel(manutencao.Id, manutencao.DataHora, manutencao.Observacoes, manutencao.Tipo, manutencao.AeronaveId);
    }

    public DetalhesManutencaoViewModel? AtualizarManutencao(AtualizarManutencaoViewModel dados)
    {
        var manutencao = _context.Manutencoes.Find(dados.Id);
        if (manutencao != null)
        {
            manutencao.DataHora = dados.DataHora;
            manutencao.Tipo = dados.Tipo;
            manutencao.AeronaveId = dados.AeronaveId;
            manutencao.Observacoes = dados.Observacoes;
            _context.Update(manutencao);
            _context.SaveChanges();
            return new DetalhesManutencaoViewModel(manutencao.Id, manutencao.DataHora, manutencao.Observacoes, manutencao.Tipo, manutencao.AeronaveId);
        }
        return null;
    }

    public IEnumerable<ListarManutencaoViewModel> ListarManutencao()
    {

        return _context.Manutencoes.Select(manutencao => new ListarManutencaoViewModel(manutencao.Id, manutencao.DataHora, manutencao.Observacoes, manutencao.Tipo, manutencao.AeronaveId));
    }

    public DetalhesManutencaoViewModel? ListarManutencaoPeloId(int id)
    {
        var manutencao = _context.Manutencoes.Find(id);
        if (manutencao != null)
        {
            return new DetalhesManutencaoViewModel(manutencao.Id, manutencao.DataHora, manutencao.Observacoes, manutencao.Tipo, manutencao.AeronaveId);
        }
        return null;
    }

    public IEnumerable<ListarManutencaoViewModel> ListarManutencoesDaAeronave(int aeronaveId){
        return _context.Manutencoes.Where(m=> m.AeronaveId == aeronaveId).Select(m=> new ListarManutencaoViewModel(m.Id, m.DataHora, m.Observacoes, m.Tipo, m.AeronaveId));
    }

    public void DeletarManutencao(int id)
    {
        var manutencao = _context.Manutencoes.Find(id);
        if (manutencao != null)
        {
            _context.Remove(manutencao);
            _context.SaveChanges();
        }
    }

}