using GPFormula1.Dominio.Entidades;
using GPFormula1.Dominio.Interfaces;
using GPFormula1.Infra.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GPFormula1.Infra.Repositorios
{
    public class PilotoRepositorio : RepositorioBase<Piloto>, IPilotoRepositorio
    {
        public PilotoRepositorio(F1DbContext Pobj_Context) : base(Pobj_Context)
        {
        }
    }
}
