namespace VoeAirlinesSenai.ViewModels;

public class DetalhesAeronaveViewModel
{
    public DetalhesAeronaveViewModel(int id, string fabricante, string codigo, string modelo)
    {
        Id = id;
        Fabricante = fabricante;
        Codigo = codigo;
        Modelo = modelo;
    }

    public int Id { get; set; }
    public string Fabricante { get; set; }
    public string Codigo { get; set; }
    public string Modelo { get; set; }
}