using GPFormula1.Dominio.Entidades;

namespace GPFormula1.Dominio.Servicos
{
    public interface IEquipeService
    {
        Task<IEnumerable<Equipe>> ListarAsync();
        Task<Equipe?> ObterPorIdAsync(int id);
        Task<Equipe> CriarAsync(Equipe equipe);
        Task<Equipe?> AtualizarAsync(int id, Equipe equipe);
        Task<bool> RemoverAsync(int id);
    }
}
