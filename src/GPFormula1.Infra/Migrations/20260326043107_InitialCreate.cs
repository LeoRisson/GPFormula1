using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GPFormula1.Infra.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Equipe",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Pais = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipe", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Piloto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Nacionalidade = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    EquipeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Piloto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Piloto_Equipe_EquipeId",
                        column: x => x.EquipeId,
                        principalTable: "Equipe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Temporada",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ano = table.Column<int>(type: "int", nullable: false),
                    CampeaoPilotosId = table.Column<int>(type: "int", nullable: true),
                    CampeaoConstrutoresId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Temporada", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Temporada_Equipe_CampeaoConstrutoresId",
                        column: x => x.CampeaoConstrutoresId,
                        principalTable: "Equipe",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Temporada_Piloto_CampeaoPilotosId",
                        column: x => x.CampeaoPilotosId,
                        principalTable: "Piloto",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GrandePremio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Local = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Circuito = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TemporadaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrandePremio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GrandePremio_Temporada_TemporadaId",
                        column: x => x.TemporadaId,
                        principalTable: "Temporada",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResultadoCorrida",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PilotoId = table.Column<int>(type: "int", nullable: false),
                    GPId = table.Column<int>(type: "int", nullable: false),
                    Posicao = table.Column<int>(type: "int", nullable: true),
                    Tempo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Voltas = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResultadoCorrida", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResultadoCorrida_GrandePremio_GPId",
                        column: x => x.GPId,
                        principalTable: "GrandePremio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResultadoCorrida_Piloto_PilotoId",
                        column: x => x.PilotoId,
                        principalTable: "Piloto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GrandePremio_TemporadaId",
                table: "GrandePremio",
                column: "TemporadaId");

            migrationBuilder.CreateIndex(
                name: "IX_Piloto_EquipeId",
                table: "Piloto",
                column: "EquipeId");

            migrationBuilder.CreateIndex(
                name: "IX_ResultadoCorrida_GPId",
                table: "ResultadoCorrida",
                column: "GPId");

            migrationBuilder.CreateIndex(
                name: "IX_ResultadoCorrida_PilotoId",
                table: "ResultadoCorrida",
                column: "PilotoId");

            migrationBuilder.CreateIndex(
                name: "IX_Temporada_CampeaoConstrutoresId",
                table: "Temporada",
                column: "CampeaoConstrutoresId");

            migrationBuilder.CreateIndex(
                name: "IX_Temporada_CampeaoPilotosId",
                table: "Temporada",
                column: "CampeaoPilotosId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ResultadoCorrida");

            migrationBuilder.DropTable(
                name: "GrandePremio");

            migrationBuilder.DropTable(
                name: "Temporada");

            migrationBuilder.DropTable(
                name: "Piloto");

            migrationBuilder.DropTable(
                name: "Equipe");
        }
    }
}
