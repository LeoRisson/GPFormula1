using GPFormula1.Api.Dtos.ResultadoCorrida;
using GPFormula1.Dominio.Entidades;
using GPFormula1.Dominio.Servicos;
using Microsoft.AspNetCore.Mvc;

namespace GPFormula1.Api.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class ResultadoCorridaController : ControllerBase
    {
        private readonly IResultadoCorridaService Aobj_ResultadoCorridaService;

        public ResultadoCorridaController(IResultadoCorridaService Pobj_ResultadoCorridaService)
        {
            Aobj_ResultadoCorridaService = Pobj_ResultadoCorridaService;
        }

        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            List<ResultadoCorrida> Lcol_ResultadosCorrida = (await Aobj_ResultadoCorridaService.ListarAsync()).ToList();
            return Ok(Lcol_ResultadosCorrida);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Obter(int id)
        {
            ResultadoCorrida? Lobj_ResultadoCorrida = await Aobj_ResultadoCorridaService.ObterPorIdAsync(id);
            return Lobj_ResultadoCorrida is null ? NotFound() : Ok(Lobj_ResultadoCorrida);
        }

        [HttpPost]
        public async Task<IActionResult> Criar(CriarResultadoCorridaDto dto)
        {
            ResultadoCorrida Lobj_ResultadoCorrida = new()
            {
                PilotoId = dto.PilotoId,
                GPId = dto.GPId,
                Posicao = dto.Posicao,
                Tempo = dto.Tempo,
                Voltas = dto.Voltas,
                Status = dto.Status
            };

            ResultadoCorrida Lobj_ResultadoCorridaCriado = await Aobj_ResultadoCorridaService.CriarAsync(Lobj_ResultadoCorrida);
            return CreatedAtAction(nameof(Obter), new { id = Lobj_ResultadoCorridaCriado.Id }, Lobj_ResultadoCorridaCriado);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(int id, AtualizarResultadoCorridaDto dto)
        {
            ResultadoCorrida Lobj_ResultadoCorrida = new()
            {
                PilotoId = dto.PilotoId,
                GPId = dto.GPId,
                Posicao = dto.Posicao,
                Tempo = dto.Tempo,
                Voltas = dto.Voltas,
                Status = dto.Status
            };

            ResultadoCorrida? Lobj_ResultadoCorridaAtualizado = await Aobj_ResultadoCorridaService.AtualizarAsync(id, Lobj_ResultadoCorrida);
            return Lobj_ResultadoCorridaAtualizado is null ? NotFound() : Ok(Lobj_ResultadoCorridaAtualizado);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remover(int id)
        {
            bool Lbl_Removido = await Aobj_ResultadoCorridaService.RemoverAsync(id);
            return Lbl_Removido ? NoContent() : NotFound();
        }
    }
}
