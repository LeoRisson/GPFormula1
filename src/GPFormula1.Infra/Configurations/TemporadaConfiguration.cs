using GPFormula1.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GPFormula1.Infra.Configurations
{
    public class TemporadaConfiguration : IEntityTypeConfiguration<Temporada>
    {
        public void Configure(EntityTypeBuilder<Temporada> builder)
        {
            builder.ToTable("Temporada");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Ano)
                .IsRequired();

            builder.HasOne(t => t.CampeaoPiloto)
                .WithMany()
                .HasForeignKey(t => t.CampeaoPilotosId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(t => t.CampeaoConstrutora)
                .WithMany()
                .HasForeignKey(t => t.CampeaoConstrutoresId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
