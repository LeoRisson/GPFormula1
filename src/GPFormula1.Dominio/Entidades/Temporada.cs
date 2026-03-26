using System;
using System.Collections.Generic;
using System.Text;

namespace GPFormula1.Dominio.Entidades
{
    public class Temporada
    {

        public int Id { get; set; }
        public int Ano { get; set; }

        public int? CampeaoPilotosId { get; set; }
        public Piloto? CampeaoPiloto { get; set; }

        public int? CampeaoConstrutoresId { get; set; }
        public Equipe? CampeaoConstrutora { get; set; }

        public ICollection<GrandePremio>? GPs { get; set; }
    }

}

