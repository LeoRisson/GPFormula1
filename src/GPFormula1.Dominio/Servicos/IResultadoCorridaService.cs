using GPFormula1.Dominio.Entidades;

namespace GPFormula1.Dominio.Servicos
{
    public interface IResultadoCorridaService
    {
        Task<IEnumerable<ResultadoCorrida>> ListarAsync();
        Task<ResultadoCorrida?> ObterPorIdAsync(int id);
        Task<ResultadoCorrida> CriarAsync(ResultadoCorrida resultadoCorrida);
        Task<ResultadoCorrida?> AtualizarAsync(int id, ResultadoCorrida resultadoCorrida);
        Task<bool> RemoverAsync(int id);
    }
}
