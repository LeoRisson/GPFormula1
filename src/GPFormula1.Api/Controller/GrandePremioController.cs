using GPFormula1.Api.Dtos.GrandePremio;
using GPFormula1.Dominio.Entidades;
using GPFormula1.Dominio.Servicos;
using Microsoft.AspNetCore.Mvc;

namespace GPFormula1.Api.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class GrandePremioController : ControllerBase
    {
        private readonly IGrandePremioService Aobj_GrandePremioService;

        public GrandePremioController(IGrandePremioService Pobj_GrandePremioService)
        {
            Aobj_GrandePremioService = Pobj_GrandePremioService;
        }

        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            List<GrandePremio> Lcol_GrandesPremios = (await Aobj_GrandePremioService.ListarAsync()).ToList();
            return Ok(Lcol_GrandesPremios);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Obter(int id)
        {
            GrandePremio? Lobj_GrandePremio = await Aobj_GrandePremioService.ObterPorIdAsync(id);
            return Lobj_GrandePremio is null ? NotFound() : Ok(Lobj_GrandePremio);
        }

        [HttpPost]
        public async Task<IActionResult> Criar(CriarGrandePremioDto dto)
        {
            GrandePremio Lobj_GrandePremio = new()
            {
                Nome = dto.Nome,
                Local = dto.Local,
                Circuito = dto.Circuito,
                Data = dto.Data,
                TemporadaId = dto.TemporadaId
            };

            GrandePremio Lobj_GrandePremioCriado = await Aobj_GrandePremioService.CriarAsync(Lobj_GrandePremio);
            return CreatedAtAction(nameof(Obter), new { id = Lobj_GrandePremioCriado.Id }, Lobj_GrandePremioCriado);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(int id, AtualizarGrandePremioDto dto)
        {
            GrandePremio Lobj_GrandePremio = new()
            {
                Nome = dto.Nome,
                Local = dto.Local,
                Circuito = dto.Circuito,
                Data = dto.Data,
                TemporadaId = dto.TemporadaId
            };

            GrandePremio? Lobj_GrandePremioAtualizado = await Aobj_GrandePremioService.AtualizarAsync(id, Lobj_GrandePremio);
            return Lobj_GrandePremioAtualizado is null ? NotFound() : Ok(Lobj_GrandePremioAtualizado);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remover(int id)
        {
            bool Lbl_Removido = await Aobj_GrandePremioService.RemoverAsync(id);
            return Lbl_Removido ? NoContent() : NotFound();
        }
    }
}
