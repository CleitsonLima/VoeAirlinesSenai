namespace VoeAirlinesSenai.ViewModels;

public class AdicionarAeronaveViewModel{
    public AdicionarAeronaveViewModel(string fabricante, string codigo, string modelo)
    {
        Fabricante = fabricante;
        Codigo = codigo;
        Modelo = modelo;
    }

    public string Fabricante { get; set; }
    public string Codigo { get; set; }
    public string Modelo { get; set; }

}
    