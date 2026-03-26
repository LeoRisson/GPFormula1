using GPFormula1.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GPFormula1.Infra.Configurations
{
    public class GrandePremioConfiguration : IEntityTypeConfiguration<GrandePremio>
    {
        public void Configure(EntityTypeBuilder<GrandePremio> builder)
        {
            builder.ToTable("GrandePremio");

            builder.HasKey(g => g.Id);

            builder.Property(g => g.Nome)
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(g => g.Local)
                .HasMaxLength(150);

            builder.Property(g => g.Circuito)
                .HasMaxLength(150);

            builder.HasOne(g => g.Temporada)
                .WithMany(t => t.GPs)
                .HasForeignKey(g => g.TemporadaId);
        }

    }
}
