using GPFormula1.Dominio.Entidades;
using GPFormula1.Dominio.Interfaces;
using GPFormula1.Dominio.Servicos;

namespace GPFormula1.Infra.Servicos
{
    public class GrandePremioService : IGrandePremioService
    {
        private readonly IGrandePremioRepositorio Aobj_GrandePremioRepositorio;

        public GrandePremioService(IGrandePremioRepositorio Pobj_GrandePremioRepositorio)
        {
            Aobj_GrandePremioRepositorio = Pobj_GrandePremioRepositorio;
        }

        public async Task<IEnumerable<GrandePremio>> ListarAsync()
        {
            return await Aobj_GrandePremioRepositorio.ListarAsync();
        }

        public async Task<GrandePremio?> ObterPorIdAsync(int id)
        {
            return await Aobj_GrandePremioRepositorio.ObterPorIdAsync(id);
        }

        public async Task<GrandePremio> CriarAsync(GrandePremio grandePremio)
        {
            if (string.IsNullOrWhiteSpace(grandePremio.Nome))
                throw new ArgumentException("Nome do Grande Prêmio é obrigatório");

            if (string.IsNullOrWhiteSpace(grandePremio.Local))
                throw new ArgumentException("Local do Grande Prêmio é obrigatório");

            if (string.IsNullOrWhiteSpace(grandePremio.Circuito))
                throw new ArgumentException("Circuito do Grande Prêmio é obrigatório");

            if (grandePremio.TemporadaId <= 0)
                throw new ArgumentException("TemporadaId é obrigatório");

            await Aobj_GrandePremioRepositorio.AdicionarAsync(grandePremio);
            return grandePremio;
        }

        public async Task<GrandePremio?> AtualizarAsync(int id, GrandePremio grandePremio)
        {
            GrandePremio? Lobj_GrandePremioExistente = await Aobj_GrandePremioRepositorio.ObterPorIdAsync(id);
            if (Lobj_GrandePremioExistente is null)
                return null;

            if (string.IsNullOrWhiteSpace(grandePremio.Nome))
                throw new ArgumentException("Nome do Grande Prêmio é obrigatório");

            if (string.IsNullOrWhiteSpace(grandePremio.Local))
                throw new ArgumentException("Local do Grande Prêmio é obrigatório");

            if (string.IsNullOrWhiteSpace(grandePremio.Circuito))
                throw new ArgumentException("Circuito do Grande Prêmio é obrigatório");

            if (grandePremio.TemporadaId <= 0)
                throw new ArgumentException("TemporadaId é obrigatório");

            Lobj_GrandePremioExistente.Nome = grandePremio.Nome;
            Lobj_GrandePremioExistente.Local = grandePremio.Local;
            Lobj_GrandePremioExistente.Circuito = grandePremio.Circuito;
            Lobj_GrandePremioExistente.Data = grandePremio.Data;
            Lobj_GrandePremioExistente.TemporadaId = grandePremio.TemporadaId;

            await Aobj_GrandePremioRepositorio.AtualizarAsync(Lobj_GrandePremioExistente);
            return Lobj_GrandePremioExistente;
        }

        public async Task<bool> RemoverAsync(int id)
        {
            GrandePremio? Lobj_GrandePremio = await Aobj_GrandePremioRepositorio.ObterPorIdAsync(id);
            if (Lobj_GrandePremio is null)
                return false;

            await Aobj_GrandePremioRepositorio.RemoverAsync(id);
            return true;
        }
    }
}
