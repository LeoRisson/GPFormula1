using GPFormula1.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GPFormula1.Infra.Data
{
    public class F1DbContext : DbContext
    {
        public F1DbContext(DbContextOptions<F1DbContext> options) : base(options)
        {
        }

        public DbSet<Piloto> Pilotos => Set<Piloto>();
        public DbSet<Equipe> Equipes => Set<Equipe>();
        public DbSet<Temporada> Temporadas => Set<Temporada>();
        public DbSet<GrandePremio> GrandePremios => Set<GrandePremio>();
        public DbSet<ResultadoCorrida> ResultadosCorrida => Set<ResultadoCorrida>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(F1DbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

    }
}
