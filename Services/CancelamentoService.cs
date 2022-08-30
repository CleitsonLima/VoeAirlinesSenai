using VoeAirlinesSenai.Contexts;
using VoeAirlinesSenai.Entities;
using VoeAirlinesSenai.ViewModels;

namespace VoeAirlinesSenai.Services;

public class CancelamentoService
{

    private readonly VoeAirLinesSenaiContext _context;

    public CancelamentoService(VoeAirLinesSenaiContext context)
    {

        _context = context;
    }

    public DetalhesCancelamentoViewModel AdicionarCancelamento(AdicionarCancelamentoViewModel dados)
    {

        var cancelamento = new Cancelamento(dados.Motivo, dados.DataHoraNotificacao, dados.VooId);
        _context.Add(cancelamento);
        _context.SaveChanges();

        return new DetalhesCancelamentoViewModel(cancelamento.Id, cancelamento.Motivo, cancelamento.DataHoraNotificacao, cancelamento.VooId);
    }

    public DetalhesCancelamentoViewModel? AtualizarCancelamento(AtualizarCancelamentoViewModel dados)
    {
        var cancelamento = _context.Cancelamentos.Find(dados.Id);
        if (cancelamento != null)
        {
            cancelamento.Motivo = dados.Motivo;
            cancelamento.DataHoraNotificacao = dados.DataHoraNotificacao;
            cancelamento.VooId = dados.VooId;
            _context.Update(cancelamento);
            _context.SaveChanges();
            return new DetalhesCancelamentoViewModel(cancelamento.Id, cancelamento.Motivo, cancelamento.DataHoraNotificacao, cancelamento.VooId);
        }
        return null;
    }

    
    public IEnumerable<ListarCancelamentoViewModel> ListarCancelamento()
    {

        return _context.Cancelamentos.Select(a => new ListarCancelamentoViewModel(a.Id,a.Motivo,a.DataHoraNotificacao,a.VooId));
    }

        public DetalhesCancelamentoViewModel? ListarCancelamentoPeloId(int id)
    {
        var cancelamento = _context.Cancelamentos.Find(id);
        if (cancelamento != null)
        {
            return new DetalhesCancelamentoViewModel(cancelamento.Id,cancelamento.Motivo,cancelamento.DataHoraNotificacao,cancelamento.VooId);
        }
        return null;
    }

        public void DeletarCancelamento(int id)
    {
        var cancelamento = _context.Cancelamentos.Find(id);
        if (cancelamento != null)
        {
            _context.Remove(cancelamento);
            _context.SaveChanges();
        }
    }
}