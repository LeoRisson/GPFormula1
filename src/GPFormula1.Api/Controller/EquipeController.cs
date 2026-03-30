using GPFormula1.Api.Dtos.Equipe;
using GPFormula1.Dominio.Entidades;
using GPFormula1.Dominio.Servicos;
using Microsoft.AspNetCore.Mvc;

namespace GPFormula1.Api.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class EquipeController : ControllerBase
    {
        private readonly IEquipeService Aobj_EquipeService;

        public EquipeController(IEquipeService Pobj_EquipeService)
        {
            Aobj_EquipeService = Pobj_EquipeService;
        }

        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            List<Equipe> Lcol_Equipes = (await Aobj_EquipeService.ListarAsync()).ToList();
            return Ok(Lcol_Equipes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Obter(int id)
        {
            Equipe? Lobj_Equipe = await Aobj_EquipeService.ObterPorIdAsync(id);
            return Lobj_Equipe is null ? NotFound() : Ok(Lobj_Equipe);
        }

        [HttpPost]
        public async Task<IActionResult> Criar(CriarEquipeDto dto)
        {
            Equipe Lobj_Equipe = new()
            {
                Nome = dto.Nome,
                Pais = dto.Pais
            };

            Equipe Lobj_EquipeCriada = await Aobj_EquipeService.CriarAsync(Lobj_Equipe);
            return CreatedAtAction(nameof(Obter), new { id = Lobj_EquipeCriada.Id }, Lobj_EquipeCriada);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(int id, AtualizarEquipeDto dto)
        {
            Equipe Lobj_Equipe = new()
            {
                Nome = dto.Nome,
                Pais = dto.Pais
            };

            Equipe? Lobj_EquipeAtualizada = await Aobj_EquipeService.AtualizarAsync(id, Lobj_Equipe);
            return Lobj_EquipeAtualizada is null ? NotFound() : Ok(Lobj_EquipeAtualizada);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remover(int id)
        {
            bool Lbl_Removido = await Aobj_EquipeService.RemoverAsync(id);
            return Lbl_Removido ? NoContent() : NotFound();
        }
    }
}
