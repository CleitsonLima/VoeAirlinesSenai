using Microsoft.EntityFrameworkCore;
using VoeAirlinesSenai.Entities;


namespace VoeAirlinesSenai.Contexts;

public class VoeAirLinesContext : DbContext
{

    public DbSet<Aeronave> Aeronaves => Set<Aeronave>();
    public DbSet<Manutencao> Manutencoes => Set<Manutencao>();

    public DbSet<Piloto> pilotos => Set<Piloto>();

    public DbSet<Voo> Voos => Set<Voo>();

    public DbSet<Cancelamento> Cancelamentos => Set<Cancelamento>();


}