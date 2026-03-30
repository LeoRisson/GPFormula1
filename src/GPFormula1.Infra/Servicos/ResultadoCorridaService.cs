using GPFormula1.Dominio.Entidades;
using GPFormula1.Dominio.Interfaces;
using GPFormula1.Dominio.Servicos;

namespace GPFormula1.Infra.Servicos
{
    public class ResultadoCorridaService : IResultadoCorridaService
    {
        private readonly IResultadoCorridaRepositorio Aobj_ResultadoCorridaRepositorio;

        public ResultadoCorridaService(IResultadoCorridaRepositorio Pobj_ResultadoCorridaRepositorio)
        {
            Aobj_ResultadoCorridaRepositorio = Pobj_ResultadoCorridaRepositorio;
        }

        public async Task<IEnumerable<ResultadoCorrida>> ListarAsync()
        {
            return await Aobj_ResultadoCorridaRepositorio.ListarAsync();
        }

        public async Task<ResultadoCorrida?> ObterPorIdAsync(int id)
        {
            return await Aobj_ResultadoCorridaRepositorio.ObterPorIdAsync(id);
        }

        public async Task<ResultadoCorrida> CriarAsync(ResultadoCorrida resultadoCorrida)
        {
            if (resultadoCorrida.PilotoId <= 0)
                throw new ArgumentException("PilotoId é obrigatório");

            if (resultadoCorrida.GPId <= 0)
                throw new ArgumentException("GrandePremioId (GPId) é obrigatório");

            if (resultadoCorrida.Posicao.HasValue && (resultadoCorrida.Posicao < 1 || resultadoCorrida.Posicao > 30))
                throw new ArgumentException("Posição deve estar entre 1 e 30");

            await Aobj_ResultadoCorridaRepositorio.AdicionarAsync(resultadoCorrida);
            return resultadoCorrida;
        }

        public async Task<ResultadoCorrida?> AtualizarAsync(int id, ResultadoCorrida resultadoCorrida)
        {
            ResultadoCorrida? Lobj_ResultadoCorridaExistente = await Aobj_ResultadoCorridaRepositorio.ObterPorIdAsync(id);
            if (Lobj_ResultadoCorridaExistente is null)
                return null;

            if (resultadoCorrida.PilotoId <= 0)
                throw new ArgumentException("PilotoId é obrigatório");

            if (resultadoCorrida.GPId <= 0)
                throw new ArgumentException("GrandePremioId (GPId) é obrigatório");

            if (resultadoCorrida.Posicao.HasValue && (resultadoCorrida.Posicao < 1 || resultadoCorrida.Posicao > 30))
                throw new ArgumentException("Posição deve estar entre 1 e 30");

            Lobj_ResultadoCorridaExistente.PilotoId = resultadoCorrida.PilotoId;
            Lobj_ResultadoCorridaExistente.GPId = resultadoCorrida.GPId;
            Lobj_ResultadoCorridaExistente.Posicao = resultadoCorrida.Posicao;
            Lobj_ResultadoCorridaExistente.Tempo = resultadoCorrida.Tempo;
            Lobj_ResultadoCorridaExistente.Voltas = resultadoCorrida.Voltas;
            Lobj_ResultadoCorridaExistente.Status = resultadoCorrida.Status;

            await Aobj_ResultadoCorridaRepositorio.AtualizarAsync(Lobj_ResultadoCorridaExistente);
            return Lobj_ResultadoCorridaExistente;
        }

        public async Task<bool> RemoverAsync(int id)
        {
            ResultadoCorrida? Lobj_ResultadoCorrida = await Aobj_ResultadoCorridaRepositorio.ObterPorIdAsync(id);
            if (Lobj_ResultadoCorrida is null)
                return false;

            await Aobj_ResultadoCorridaRepositorio.RemoverAsync(id);
            return true;
        }
    }
}
