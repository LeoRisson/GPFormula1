using GPFormula1.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GPFormula1.Infra.Configurations
{
    public class EquipeConfiguration : IEntityTypeConfiguration<Equipe>
    {
        public void Configure(EntityTypeBuilder<Equipe> builder)
        {
            builder.ToTable("Equipe");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Nome)
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(e => e.Pais)
                .HasMaxLength(100);
        }

    }
}
