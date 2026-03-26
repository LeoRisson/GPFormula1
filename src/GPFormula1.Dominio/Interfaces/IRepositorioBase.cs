using System;
using System.Collections.Generic;
using System.Text;

namespace GPFormula1.Dominio.Interfaces
{
    public interface IRepositorioBase<T> where T : class
    {
        Task<T?> ObterPorIdAsync(int id);
        Task<IEnumerable<T>> ListarAsync();
        Task AdicionarAsync(T entidade);
        Task AtualizarAsync(T entidade);
        Task RemoverAsync(int id);
    }

}
