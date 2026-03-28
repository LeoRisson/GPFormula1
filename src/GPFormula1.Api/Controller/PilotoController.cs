using GPFormula1.Api.Dtos.Piloto;
using GPFormula1.Dominio.Entidades;
using GPFormula1.Dominio.Servicos;
using Microsoft.AspNetCore.Mvc;

namespace GPFormula1.Api.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class PilotoController : ControllerBase
    {
        private readonly IPilotoService Aobj_PilotoService;

        public PilotoController(IPilotoService Pobj_PilotoService)
        {
            Aobj_PilotoService = Pobj_PilotoService;
        }

        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            List<Piloto> Lcol_Pilotos = (await Aobj_PilotoService.ListarAsync()).ToList();
            //var pilotos = await Aobj_PilotoService.ListarAsync();
            return Ok(Lcol_Pilotos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Obter(int id)
        {
            Piloto? Lobj_Piloto = await Aobj_PilotoService.ObterPorIdAsync(id);
            return Lobj_Piloto is null ? NotFound() : Ok(Lobj_Piloto);
        }

        [HttpPost]
        public async Task<IActionResult> Criar(CriarPilotoDto dto)
        {
            Piloto Lobj_Piloto = new()
            {
                Nome = dto.Nome,
                Nacionalidade = dto.Nacionalidade,
                Numero = dto.NumeroCarro,
                EquipeId = dto.EquipeId
            };

            Piloto Lobj_PilotoCriado = await Aobj_PilotoService.CriarAsync(Lobj_Piloto);
            return CreatedAtAction(nameof(Obter), new { id = Lobj_PilotoCriado.Id }, Lobj_PilotoCriado);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(int id, AtualizarPilotoDto dto)
        {
            Piloto Lobj_Piloto = new()
            {
                Nome = dto.Nome,
                Nacionalidade = dto.Nacionalidade,
                Numero = dto.NumeroCarro,
                EquipeId = dto.EquipeId
            };

            Piloto? Lobj_PilotoAtualizado = await Aobj_PilotoService.AtualizarAsync(id, Lobj_Piloto);
            return Lobj_PilotoAtualizado is null ? NotFound() : Ok(Lobj_PilotoAtualizado);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remover(int id)
        {
            bool Lbl_Removido = await Aobj_PilotoService.RemoverAsync(id);
            return Lbl_Removido ? NoContent() : NotFound();
        }

    }
}
