using GPFormula1.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GPFormula1.Infra.Configurations
{
    public class PilotoConfiguration : IEntityTypeConfiguration<Piloto>
    {
        public void Configure(EntityTypeBuilder<Piloto> builder)
        {
            builder.ToTable("Piloto");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(p => p.Nacionalidade)
                .HasMaxLength(100);

            builder.HasOne(p => p.Equipe)
                .WithMany(e => e.Pilotos)
                .HasForeignKey(p => p.EquipeId);
        }
    }
}
