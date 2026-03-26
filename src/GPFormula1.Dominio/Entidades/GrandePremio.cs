using System;
using System.Collections.Generic;
using System.Text;

namespace GPFormula1.Dominio.Entidades
{
    public class GrandePremio
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Local { get; set; } = string.Empty;
        public string Circuito { get; set; } = string.Empty;
        public DateTime Data { get; set; }

        public int TemporadaId { get; set; }
        public Temporada? Temporada { get; set; }

        public ICollection<ResultadoCorrida>? Resultados { get; set; }
    }

}

