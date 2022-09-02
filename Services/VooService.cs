using DinkToPdf;
using DinkToPdf.Contracts;
using System.Text;
using Microsoft.EntityFrameworkCore;
using VoeAirlinesSenai.Contexts;
using VoeAirlinesSenai.Entities;
using VoeAirlinesSenai.ViewModels;

namespace VoeAirlinesSenai.Services;



public class VooService
{
    private readonly VoeAirLinesSenaiContext _context;
    private readonly IConverter _converter;
    private readonly IHostEnvironment _hostEnvironment;

    public VooService(VoeAirLinesSenaiContext context, IConverter converter, IHostEnvironment hostEnvironment)
    {
        _context = context;
        _converter = converter;
        this._hostEnvironment = hostEnvironment;
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

    public byte[]? GerarFichaDoVoo(int id)
    {
        var voo = _context.Voos.Include(v => v.Aeronave)
                           .Include(v => v.Piloto)
                           .Include(v => v.Cancelamento)
                           .FirstOrDefault(v => v.Id == id);

        var path = _hostEnvironment.ContentRootPath + "\\banner-voeairlines.png";
        if (voo != null)
        {
            var builder = new StringBuilder();

            builder.Append($"<img src='{path}' width= '1000'/>")
            .Append($"<h1 style='text-align: center'>Ficha do Voo {voo.Id.ToString().PadLeft(10, '0')}</h1>")                   
            .Append($"<hr>")
            .Append($"<p><b>ORIGEM:</b> {voo.Origem} (saída em {voo.DataHoraPartida:dd/MM/yyyy} às {voo.DataHoraPartida:hh:mm})</p>")
            .Append($"<p><b>DESTINO:</b> {voo.Destino} (chegada em {voo.DataHoraChegada:dd/MM/yyyy} às {voo.DataHoraChegada:hh:mm})</p>")
            .Append($"<hr>")
            .Append($"<p><b>AERONAVE:</b> {voo.Aeronave!.Codigo} ({voo.Aeronave.Fabricante} {voo.Aeronave.Modelo})</p>")
            .Append($"<hr>")
            .Append($"<p><b>PILOTO:</b> {voo.Piloto!.Nome} ({voo.Piloto.Matricula})</p>")
            .Append($"<hr>");
            if (voo.Cancelamento != null)
            {
                builder.Append($"<p style='color: red'><b>VOO CANCELADO:</b> {voo.Cancelamento.Motivo}</p>");
            }

            var doc = new HtmlToPdfDocument()
            {
                GlobalSettings = {
                    ColorMode = ColorMode.Color,
                    Orientation = Orientation.Portrait,
                    PaperSize = PaperKind.A4
                },
                Objects = {
                    new ObjectSettings() {
                        PagesCount = true,
                        HtmlContent = builder.ToString(),
                        WebSettings = { DefaultEncoding = "utf-8" }

                    }
                }
            };

            return _converter.Convert(doc);
        }

        return null;
    }
}
