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

            // Seed Data - Equipes F1 2024
            modelBuilder.Entity<Equipe>().HasData(
                new Equipe { Id = 1, Nome = "Red Bull Racing", Pais = "Áustria" },
                new Equipe { Id = 2, Nome = "Ferrari", Pais = "Itália" },
                new Equipe { Id = 3, Nome = "Mercedes", Pais = "Alemanha" },
                new Equipe { Id = 4, Nome = "McLaren", Pais = "Reino Unido" },
                new Equipe { Id = 5, Nome = "Aston Martin", Pais = "Reino Unido" },
                new Equipe { Id = 6, Nome = "Alpine", Pais = "França" },
                new Equipe { Id = 7, Nome = "Williams", Pais = "Reino Unido" },
                new Equipe { Id = 8, Nome = "RB", Pais = "Itália" },
                new Equipe { Id = 9, Nome = "Kick Sauber", Pais = "Suíça" },
                new Equipe { Id = 10, Nome = "Haas", Pais = "Estados Unidos" }
            );

            // Seed Data - Pilotos F1 2024
            modelBuilder.Entity<Piloto>().HasData(
                // Red Bull Racing
                new Piloto { Id = 1, Nome = "Max Verstappen", Nacionalidade = "Holanda", Numero = 1, EquipeId = 1 },
                new Piloto { Id = 2, Nome = "Sergio Perez", Nacionalidade = "México", Numero = 11, EquipeId = 1 },

                // Ferrari
                new Piloto { Id = 3, Nome = "Charles Leclerc", Nacionalidade = "Mônaco", Numero = 16, EquipeId = 2 },
                new Piloto { Id = 4, Nome = "Carlos Sainz", Nacionalidade = "Espanha", Numero = 55, EquipeId = 2 },

                // Mercedes
                new Piloto { Id = 5, Nome = "Lewis Hamilton", Nacionalidade = "Reino Unido", Numero = 44, EquipeId = 3 },
                new Piloto { Id = 6, Nome = "George Russell", Nacionalidade = "Reino Unido", Numero = 63, EquipeId = 3 },

                // McLaren
                new Piloto { Id = 7, Nome = "Lando Norris", Nacionalidade = "Reino Unido", Numero = 4, EquipeId = 4 },
                new Piloto { Id = 8, Nome = "Oscar Piastri", Nacionalidade = "Austrália", Numero = 81, EquipeId = 4 },

                // Aston Martin
                new Piloto { Id = 9, Nome = "Fernando Alonso", Nacionalidade = "Espanha", Numero = 14, EquipeId = 5 },
                new Piloto { Id = 10, Nome = "Lance Stroll", Nacionalidade = "Canadá", Numero = 18, EquipeId = 5 },

                // Alpine
                new Piloto { Id = 11, Nome = "Pierre Gasly", Nacionalidade = "França", Numero = 10, EquipeId = 6 },
                new Piloto { Id = 12, Nome = "Esteban Ocon", Nacionalidade = "França", Numero = 31, EquipeId = 6 },

                // Williams
                new Piloto { Id = 13, Nome = "Alexander Albon", Nacionalidade = "Tailândia", Numero = 23, EquipeId = 7 },
                new Piloto { Id = 14, Nome = "Logan Sargeant", Nacionalidade = "Estados Unidos", Numero = 2, EquipeId = 7 },

                // RB
                new Piloto { Id = 15, Nome = "Yuki Tsunoda", Nacionalidade = "Japão", Numero = 22, EquipeId = 8 },
                new Piloto { Id = 16, Nome = "Daniel Ricciardo", Nacionalidade = "Austrália", Numero = 3, EquipeId = 8 },

                // Kick Sauber
                new Piloto { Id = 17, Nome = "Valtteri Bottas", Nacionalidade = "Finlândia", Numero = 77, EquipeId = 9 },
                new Piloto { Id = 18, Nome = "Zhou Guanyu", Nacionalidade = "China", Numero = 24, EquipeId = 9 },

                // Haas
                new Piloto { Id = 19, Nome = "Kevin Magnussen", Nacionalidade = "Dinamarca", Numero = 20, EquipeId = 10 },
                new Piloto { Id = 20, Nome = "Nico Hulkenberg", Nacionalidade = "Alemanha", Numero = 27, EquipeId = 10 }
            );

            // Seed Data - Temporada 2024
            modelBuilder.Entity<Temporada>().HasData(
                new Temporada { Id = 1, Ano = 2024, CampeaoPilotosId = null, CampeaoConstrutoresId = null }
            );

            // Seed Data - Grandes Prêmios 2024 (principais)
            modelBuilder.Entity<GrandePremio>().HasData(
                new GrandePremio 
                { 
                    Id = 1, 
                    Nome = "GP do Brasil", 
                    Local = "São Paulo", 
                    Circuito = "Autódromo José Carlos Pace (Interlagos)", 
                    Data = new DateTime(2024, 11, 3, 14, 0, 0),
                    TemporadaId = 1 
                },
                new GrandePremio 
                { 
                    Id = 2, 
                    Nome = "GP de Mônaco", 
                    Local = "Monte Carlo", 
                    Circuito = "Circuit de Monaco", 
                    Data = new DateTime(2024, 5, 26, 15, 0, 0),
                    TemporadaId = 1 
                },
                new GrandePremio 
                { 
                    Id = 3, 
                    Nome = "GP da Itália", 
                    Local = "Monza", 
                    Circuito = "Autodromo Nazionale di Monza", 
                    Data = new DateTime(2024, 9, 1, 15, 0, 0),
                    TemporadaId = 1 
                },
                new GrandePremio 
                { 
                    Id = 4, 
                    Nome = "GP da Inglaterra", 
                    Local = "Silverstone", 
                    Circuito = "Silverstone Circuit", 
                    Data = new DateTime(2024, 7, 7, 15, 0, 0),
                    TemporadaId = 1 
                },
                new GrandePremio 
                { 
                    Id = 5, 
                    Nome = "GP da Bélgica", 
                    Local = "Spa-Francorchamps", 
                    Circuito = "Circuit de Spa-Francorchamps", 
                    Data = new DateTime(2024, 7, 28, 15, 0, 0),
                    TemporadaId = 1 
                }
            );

            base.OnModelCreating(modelBuilder);
        }

    }
}
