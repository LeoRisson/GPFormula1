using System;
using System.Collections.Generic;
using System.Text;

namespace GPFormula1.Dominio.Entidades
{
    public class Equipe
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Pais { get; set; } = string.Empty;

        public ICollection<Piloto>? Pilotos { get; set; }
    }
}
