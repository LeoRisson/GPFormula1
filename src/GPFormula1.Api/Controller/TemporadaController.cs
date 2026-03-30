using GPFormula1.Api.Dtos.Temporada;
using GPFormula1.Dominio.Entidades;
using GPFormula1.Dominio.Servicos;
using Microsoft.AspNetCore.Mvc;

namespace GPFormula1.Api.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class TemporadaController : ControllerBase
    {
        private readonly ITemporadaService Aobj_TemporadaService;

        public TemporadaController(ITemporadaService Pobj_TemporadaService)
        {
            Aobj_TemporadaService = Pobj_TemporadaService;
        }

        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            List<Temporada> Lcol_Temporadas = (await Aobj_TemporadaService.ListarAsync()).ToList();
            return Ok(Lcol_Temporadas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Obter(int id)
        {
            Temporada? Lobj_Temporada = await Aobj_TemporadaService.ObterPorIdAsync(id);
            return Lobj_Temporada is null ? NotFound() : Ok(Lobj_Temporada);
        }

        [HttpPost]
        public async Task<IActionResult> Criar(CriarTemporadaDto dto)
        {
            Temporada Lobj_Temporada = new()
            {
                Ano = dto.Ano,
                CampeaoPilotosId = dto.CampeaoPilotosId,
                CampeaoConstrutoresId = dto.CampeaoConstrutoresId
            };

            Temporada Lobj_TemporadaCriada = await Aobj_TemporadaService.CriarAsync(Lobj_Temporada);
            return CreatedAtAction(nameof(Obter), new { id = Lobj_TemporadaCriada.Id }, Lobj_TemporadaCriada);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(int id, AtualizarTemporadaDto dto)
        {
            Temporada Lobj_Temporada = new()
            {
                Ano = dto.Ano,
                CampeaoPilotosId = dto.CampeaoPilotosId,
                CampeaoConstrutoresId = dto.CampeaoConstrutoresId
            };

            Temporada? Lobj_TemporadaAtualizada = await Aobj_TemporadaService.AtualizarAsync(id, Lobj_Temporada);
            return Lobj_TemporadaAtualizada is null ? NotFound() : Ok(Lobj_TemporadaAtualizada);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remover(int id)
        {
            bool Lbl_Removido = await Aobj_TemporadaService.RemoverAsync(id);
            return Lbl_Removido ? NoContent() : NotFound();
        }
    }
}
