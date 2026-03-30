using GPFormula1.Dominio.Entidades;
using GPFormula1.Dominio.Interfaces;
using GPFormula1.Dominio.Servicos;

namespace GPFormula1.Infra.Servicos
{
    public class TemporadaService : ITemporadaService
    {
        private readonly ITemporadaRepositorio Aobj_TemporadaRepositorio;

        public TemporadaService(ITemporadaRepositorio Pobj_TemporadaRepositorio)
        {
            Aobj_TemporadaRepositorio = Pobj_TemporadaRepositorio;
        }

        public async Task<IEnumerable<Temporada>> ListarAsync()
        {
            return await Aobj_TemporadaRepositorio.ListarAsync();
        }

        public async Task<Temporada?> ObterPorIdAsync(int id)
        {
            return await Aobj_TemporadaRepositorio.ObterPorIdAsync(id);
        }

        public async Task<Temporada> CriarAsync(Temporada temporada)
        {
            if (temporada.Ano < 1950)
                throw new ArgumentException("Ano da temporada deve ser 1950 ou superior (início da F1)");

            if (temporada.Ano > DateTime.Now.Year + 1)
                throw new ArgumentException($"Ano da temporada não pode ser maior que {DateTime.Now.Year + 1}");

            await Aobj_TemporadaRepositorio.AdicionarAsync(temporada);
            return temporada;
        }

        public async Task<Temporada?> AtualizarAsync(int id, Temporada temporada)
        {
            Temporada? Lobj_TemporadaExistente = await Aobj_TemporadaRepositorio.ObterPorIdAsync(id);
            if (Lobj_TemporadaExistente is null)
                return null;

            if (temporada.Ano < 1950)
                throw new ArgumentException("Ano da temporada deve ser 1950 ou superior (início da F1)");

            if (temporada.Ano > DateTime.Now.Year + 1)
                throw new ArgumentException($"Ano da temporada não pode ser maior que {DateTime.Now.Year + 1}");

            Lobj_TemporadaExistente.Ano = temporada.Ano;
            Lobj_TemporadaExistente.CampeaoPilotosId = temporada.CampeaoPilotosId;
            Lobj_TemporadaExistente.CampeaoConstrutoresId = temporada.CampeaoConstrutoresId;

            await Aobj_TemporadaRepositorio.AtualizarAsync(Lobj_TemporadaExistente);
            return Lobj_TemporadaExistente;
        }

        public async Task<bool> RemoverAsync(int id)
        {
            Temporada? Lobj_Temporada = await Aobj_TemporadaRepositorio.ObterPorIdAsync(id);
            if (Lobj_Temporada is null)
                return false;

            await Aobj_TemporadaRepositorio.RemoverAsync(id);
            return true;
        }
    }
}
