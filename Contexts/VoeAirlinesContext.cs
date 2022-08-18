using Microsoft.EntityFrameworkCore;
using VoeAirlinesSenai.Entities;


namespace VoeAirlinesSenai.Contexts;

public class VoeAirLinesSenaiContext : DbContext
{
    private readonly IConfiguration _configuration;

    public VoeAirLinesSenaiContext(IConfiguration configuration)
    {

        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_configuration.GetConnectionString("VoeAirlinesSenai"));
    }


    public DbSet<Aeronave> Aeronaves => Set<Aeronave>();
    public DbSet<Manutencao> Manutencoes => Set<Manutencao>();

    public DbSet<Piloto> pilotos => Set<Piloto>();

    public DbSet<Voo> Voos => Set<Voo>();

    public DbSet<Cancelamento> Cancelamentos => Set<Cancelamento>();


}
