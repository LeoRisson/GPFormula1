using GPFormula1.Dominio.Interfaces;
using GPFormula1.Infra.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GPFormula1.Infra.Repositorios
{
    public class RepositorioBase<T> : IRepositorioBase<T> where T : class
    {
        protected readonly F1DbContext Aobj_Context;

        public RepositorioBase(F1DbContext Pobj_Context)
        {
            Aobj_Context = Pobj_Context;
        }

        public async Task<T?> ObterPorIdAsync(int id)
            => await Aobj_Context.Set<T>().FindAsync(id);

        public async Task<IEnumerable<T>> ListarAsync()
            => await Aobj_Context.Set<T>().ToListAsync();

        public async Task AdicionarAsync(T entidade)
        {
            Aobj_Context.Set<T>().Add(entidade);
            await Aobj_Context.SaveChangesAsync();
        }

        public async Task AtualizarAsync(T entidade)
        {
            Aobj_Context.Set<T>().Update(entidade);
            await Aobj_Context.SaveChangesAsync();
        }

        public async Task RemoverAsync(int id)
        {
            var entidade = await ObterPorIdAsync(id);
            if (entidade != null)
            {
                Aobj_Context.Set<T>().Remove(entidade);
                await Aobj_Context.SaveChangesAsync();
            }
        }

    }
}
