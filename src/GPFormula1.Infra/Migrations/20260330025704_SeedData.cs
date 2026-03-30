using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GPFormula1.Infra.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Equipe",
                columns: new[] { "Id", "Nome", "Pais" },
                values: new object[,]
                {
                    { 1, "Red Bull Racing", "Áustria" },
                    { 2, "Ferrari", "Itália" },
                    { 3, "Mercedes", "Alemanha" },
                    { 4, "McLaren", "Reino Unido" },
                    { 5, "Aston Martin", "Reino Unido" },
                    { 6, "Alpine", "França" },
                    { 7, "Williams", "Reino Unido" },
                    { 8, "RB", "Itália" },
                    { 9, "Kick Sauber", "Suíça" },
                    { 10, "Haas", "Estados Unidos" }
                });

            migrationBuilder.InsertData(
                table: "Temporada",
                columns: new[] { "Id", "Ano", "CampeaoConstrutoresId", "CampeaoPilotosId" },
                values: new object[] { 1, 2024, null, null });

            migrationBuilder.InsertData(
                table: "GrandePremio",
                columns: new[] { "Id", "Circuito", "Data", "Local", "Nome", "TemporadaId" },
                values: new object[,]
                {
                    { 1, "Autódromo José Carlos Pace (Interlagos)", new DateTime(2024, 11, 3, 14, 0, 0, 0, DateTimeKind.Unspecified), "São Paulo", "GP do Brasil", 1 },
                    { 2, "Circuit de Monaco", new DateTime(2024, 5, 26, 15, 0, 0, 0, DateTimeKind.Unspecified), "Monte Carlo", "GP de Mônaco", 1 },
                    { 3, "Autodromo Nazionale di Monza", new DateTime(2024, 9, 1, 15, 0, 0, 0, DateTimeKind.Unspecified), "Monza", "GP da Itália", 1 },
                    { 4, "Silverstone Circuit", new DateTime(2024, 7, 7, 15, 0, 0, 0, DateTimeKind.Unspecified), "Silverstone", "GP da Inglaterra", 1 },
                    { 5, "Circuit de Spa-Francorchamps", new DateTime(2024, 7, 28, 15, 0, 0, 0, DateTimeKind.Unspecified), "Spa-Francorchamps", "GP da Bélgica", 1 }
                });

            migrationBuilder.InsertData(
                table: "Piloto",
                columns: new[] { "Id", "EquipeId", "Nacionalidade", "Nome", "Numero" },
                values: new object[,]
                {
                    { 1, 1, "Holanda", "Max Verstappen", 1 },
                    { 2, 1, "México", "Sergio Perez", 11 },
                    { 3, 2, "Mônaco", "Charles Leclerc", 16 },
                    { 4, 2, "Espanha", "Carlos Sainz", 55 },
                    { 5, 3, "Reino Unido", "Lewis Hamilton", 44 },
                    { 6, 3, "Reino Unido", "George Russell", 63 },
                    { 7, 4, "Reino Unido", "Lando Norris", 4 },
                    { 8, 4, "Austrália", "Oscar Piastri", 81 },
                    { 9, 5, "Espanha", "Fernando Alonso", 14 },
                    { 10, 5, "Canadá", "Lance Stroll", 18 },
                    { 11, 6, "França", "Pierre Gasly", 10 },
                    { 12, 6, "França", "Esteban Ocon", 31 },
                    { 13, 7, "Tailândia", "Alexander Albon", 23 },
                    { 14, 7, "Estados Unidos", "Logan Sargeant", 2 },
                    { 15, 8, "Japão", "Yuki Tsunoda", 22 },
                    { 16, 8, "Austrália", "Daniel Ricciardo", 3 },
                    { 17, 9, "Finlândia", "Valtteri Bottas", 77 },
                    { 18, 9, "China", "Zhou Guanyu", 24 },
                    { 19, 10, "Dinamarca", "Kevin Magnussen", 20 },
                    { 20, 10, "Alemanha", "Nico Hulkenberg", 27 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "GrandePremio",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "GrandePremio",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "GrandePremio",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "GrandePremio",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "GrandePremio",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Piloto",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Piloto",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Piloto",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Piloto",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Piloto",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Piloto",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Piloto",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Piloto",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Piloto",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Piloto",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Piloto",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Piloto",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Piloto",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Piloto",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Piloto",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Piloto",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Piloto",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Piloto",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Piloto",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Piloto",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Equipe",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Equipe",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Equipe",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Equipe",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Equipe",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Equipe",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Equipe",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Equipe",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Equipe",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Equipe",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Temporada",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
