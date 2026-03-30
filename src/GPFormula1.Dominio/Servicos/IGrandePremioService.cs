using GPFormula1.Dominio.Entidades;

namespace GPFormula1.Dominio.Servicos
{
    public interface IGrandePremioService
    {
        Task<IEnumerable<GrandePremio>> ListarAsync();
        Task<GrandePremio?> ObterPorIdAsync(int id);
        Task<GrandePremio> CriarAsync(GrandePremio grandePremio);
        Task<GrandePremio?> AtualizarAsync(int id, GrandePremio grandePremio);
        Task<bool> RemoverAsync(int id);
    }
}
