using VoeAirlinesSenai.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VoeAirlinesSenai.EntityConfigurations;
public class PilotoConfiguration : IEntityTypeConfiguration<Piloto>
{
    public void Configure(EntityTypeBuilder<Piloto> builder)
    {
        builder.ToTable("Piloto");
        builder.HasKey(m => m.Id);
        builder.Property(m => m.Nome)
                .IsRequired()
                .HasMaxLength(80);
        builder.Property(m => m.Matricula)
                .IsRequired()
                .HasMaxLength(10);
        builder.HasIndex(p => p.Matricula)
                .IsUnique();
        builder.HasMany(v=>v.Voos)
                .WithOne(p=> p.Piloto)
                .HasForeignKey(p=> p.PilotoId);
    }

}