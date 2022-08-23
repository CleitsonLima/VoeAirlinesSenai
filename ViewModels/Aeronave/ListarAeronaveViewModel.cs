namespace VoeAirlinesSenai.ViewModels;

public class ListarAeronaveViewModel
{
    public ListarAeronaveViewModel(int id, string codigo, string modelo)
    {
        Id = id;
        Codigo = codigo;
        Modelo = modelo;
    }

    public int Id { get; set; }
    public string Codigo { get; set; }
    public string Modelo { get; set; }
}