using GPFormula1.Dominio.Entidades;
using GPFormula1.Dominio.Interfaces;
using GPFormula1.Dominio.Servicos;
using System;
using System.Collections.Generic;
using System.Text;

namespace GPFormula1.Infra.Servicos
{
    public class PilotoService : IPilotoService
    {
        private readonly IPilotoRepositorio Aobj_Repositorio;

        public PilotoService(IPilotoRepositorio Pobj_Repositorio)
        {
            Aobj_Repositorio = Pobj_Repositorio;
        }

        public Task<IEnumerable<Piloto>> ListarAsync()
            => Aobj_Repositorio.ListarAsync();

        public Task<Piloto?> ObterPorIdAsync(int id)
            => Aobj_Repositorio.ObterPorIdAsync(id);

        public async Task<Piloto> CriarAsync(Piloto piloto)
        {
            await Aobj_Repositorio.AdicionarAsync(piloto);
            return piloto;
        }

        public async Task<Piloto?> AtualizarAsync(int id, Piloto piloto)
        {
            Piloto? Lobj_Piloto = await Aobj_Repositorio.ObterPorIdAsync(id);
            if (Lobj_Piloto == null)
                return null;

            Lobj_Piloto.Nome = piloto.Nome;
            Lobj_Piloto.Nacionalidade = piloto.Nacionalidade;
            Lobj_Piloto.Numero = piloto.Numero;
            Lobj_Piloto.EquipeId = piloto.EquipeId;

            await Aobj_Repositorio.AtualizarAsync(Lobj_Piloto);
            return Lobj_Piloto;
        }

        public async Task<bool> RemoverAsync(int id)
        {
            var existente = await Aobj_Repositorio.ObterPorIdAsync(id);
            if (existente == null)
                return false;

            await Aobj_Repositorio.RemoverAsync(id);
            return true;
        }

    }
}
