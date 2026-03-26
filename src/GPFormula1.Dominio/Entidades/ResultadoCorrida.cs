using System;
using System.Collections.Generic;
using System.Text;

namespace GPFormula1.Dominio.Entidades
{
    public class ResultadoCorrida
    {
        public int Id { get; set; }

        public int PilotoId { get; set; }
        public Piloto? Piloto { get; set; }

        public int GPId { get; set; }
        public GrandePremio? GP { get; set; }

        public int? Posicao { get; set; }
        public string? Tempo { get; set; }
        public int? Voltas { get; set; }
        public string? Status { get; set; }

    }
}
