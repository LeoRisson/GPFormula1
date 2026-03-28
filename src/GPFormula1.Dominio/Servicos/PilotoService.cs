using GPFormula1.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace GPFormula1.Dominio.Servicos
{
    public interface IPilotoService
    {
        Task<IEnumerable<Piloto>> ListarAsync();
        Task<Piloto?> ObterPorIdAsync(int id);
        Task<Piloto> CriarAsync(Piloto piloto);
        Task<Piloto?> AtualizarAsync(int id, Piloto piloto);
        Task<bool> RemoverAsync(int id);

    }
}
