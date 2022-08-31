// Namespace é um conjunto de classes
//Namespace é uma divisão lógica
namespace VoeAirlinesSenai.Entities;

// Classe é o conjunto de objetos
// Objeto é uma instância de uma classe
public class Aeronave
{
    public Aeronave(string fabricante, string codigo, string modelo)
    {
        Fabricante = fabricante;
        Codigo = codigo;
        Modelo = modelo;
    }

    public int Id { get; set; }
    public string Fabricante { get; set; }
    public string Codigo { get; set; }
    public string Modelo { get; set; }
    public ICollection<Manutencao> Manutencoes { get; set; } = null!;
    public ICollection<Voo> Voos { get; set; } = null!;


}

// Properiedades Automáticas
// Características do objeto
// Automático: gera get e set
// Metodo set - atribui
// Método get - recupera
// POCO - o foco é o objeto
