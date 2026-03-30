using GPFormula1.Dominio.Entidades;
using GPFormula1.Dominio.Interfaces;
using GPFormula1.Dominio.Servicos;

namespace GPFormula1.Infra.Servicos
{
    public class EquipeService : IEquipeService
    {
        private readonly IEquipeRepositorio Aobj_EquipeRepositorio;

        public EquipeService(IEquipeRepositorio Pobj_EquipeRepositorio)
        {
            Aobj_EquipeRepositorio = Pobj_EquipeRepositorio;
        }

        public async Task<IEnumerable<Equipe>> ListarAsync()
        {
            return await Aobj_EquipeRepositorio.ListarAsync();
        }

        public async Task<Equipe?> ObterPorIdAsync(int id)
        {
            return await Aobj_EquipeRepositorio.ObterPorIdAsync(id);
        }

        public async Task<Equipe> CriarAsync(Equipe equipe)
        {
            if (string.IsNullOrWhiteSpace(equipe.Nome))
                throw new ArgumentException("Nome da equipe é obrigatório");

            if (string.IsNullOrWhiteSpace(equipe.Pais))
                throw new ArgumentException("País da equipe é obrigatório");

            await Aobj_EquipeRepositorio.AdicionarAsync(equipe);
            return equipe;
        }

        public async Task<Equipe?> AtualizarAsync(int id, Equipe equipe)
        {
            Equipe? Lobj_EquipeExistente = await Aobj_EquipeRepositorio.ObterPorIdAsync(id);
            if (Lobj_EquipeExistente is null)
                return null;

            if (string.IsNullOrWhiteSpace(equipe.Nome))
                throw new ArgumentException("Nome da equipe é obrigatório");

            if (string.IsNullOrWhiteSpace(equipe.Pais))
                throw new ArgumentException("País da equipe é obrigatório");

            Lobj_EquipeExistente.Nome = equipe.Nome;
            Lobj_EquipeExistente.Pais = equipe.Pais;

            await Aobj_EquipeRepositorio.AtualizarAsync(Lobj_EquipeExistente);
            return Lobj_EquipeExistente;
        }

        public async Task<bool> RemoverAsync(int id)
        {
            Equipe? Lobj_Equipe = await Aobj_EquipeRepositorio.ObterPorIdAsync(id);
            if (Lobj_Equipe is null)
                return false;

            await Aobj_EquipeRepositorio.RemoverAsync(id);
            return true;
        }
    }
}
