using System;
using System.Collections.Generic;
using System.Text;

namespace GPFormula1.Dominio.Entidades
{
    public class Piloto
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Nacionalidade { get; set; } = string.Empty;
        public int Numero { get; set; }

        public int EquipeId { get; set; }
        public Equipe? Equipe { get; set; }
    }
}
