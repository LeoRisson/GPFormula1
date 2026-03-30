using GPFormula1.Dominio.Entidades;

namespace GPFormula1.Dominio.Servicos
{
    public interface ITemporadaService
    {
        Task<IEnumerable<Temporada>> ListarAsync();
        Task<Temporada?> ObterPorIdAsync(int id);
        Task<Temporada> CriarAsync(Temporada temporada);
        Task<Temporada?> AtualizarAsync(int id, Temporada temporada);
        Task<bool> RemoverAsync(int id);
    }
}
