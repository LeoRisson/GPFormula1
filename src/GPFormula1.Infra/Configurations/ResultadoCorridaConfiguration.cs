using GPFormula1.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GPFormula1.Infra.Configurations
{
    public class ResultadoCorridaConfiguration : IEntityTypeConfiguration<ResultadoCorrida>
    {
        public void Configure(EntityTypeBuilder<ResultadoCorrida> builder)
        {
            builder.ToTable("ResultadoCorrida");

            builder.HasKey(r => r.Id);

            builder.HasOne(r => r.Piloto)
                .WithMany()
                .HasForeignKey(r => r.PilotoId);

            builder.HasOne(r => r.GP)
                .WithMany(g => g.Resultados)
                .HasForeignKey(r => r.GPId);
        }

    };
}
