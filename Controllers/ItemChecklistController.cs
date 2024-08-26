using ChecklistApi.DTO_s;
using ChecklistApi.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ChecklistApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemChecklistController: ControllerBase
    {
        private readonly IItemChecklistService _itemChecklistService;

        public ItemChecklistController(IItemChecklistService itemChecklistService)
        {
            _itemChecklistService = itemChecklistService;
        }

        /// <summary>
        /// Obtém um item do checklist específico pelo seu ID.
        /// </summary>
        /// <param name="id">O ID do item do checklist a ser obtido.</param>
        /// <returns>O item do checklist correspondente ao ID fornecido.</returns>

        [HttpGet("{id}")]
        public async Task<ActionResult<ItemChecklistDTO>> GetItemChecklistById(int id)
        {
            var itemChecklist = await _itemChecklistService.GetItemChecklistById(id);

            if (itemChecklist == null)
            {
                return NotFound();
            }

            return Ok(itemChecklist);
        }

        /// <summary>
        /// Obtém todos os itens do checklist.
        /// </summary>
        /// <returns>Uma lista de todos os itens do checklist.</returns>

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemChecklistDTO>>> GertAllItemChecklist()
        {
            var itemChecklist = await _itemChecklistService.GetAllAsync();
            return Ok(itemChecklist);
        }

        /// <summary>
        /// Adiciona um novo item ao checklist.
        /// </summary>
        /// <param name="itemChecklistDTO">Os dados do item do checklist a ser adicionado.</param>
        /// <returns>O item do checklist adicionado.</returns>

        [HttpPost]
        public async Task<ActionResult> AddItemChecklist([FromBody] ItemChecklistDTO itemChecklistDTO)
        {
            await _itemChecklistService.AddAsync(itemChecklistDTO);
            return CreatedAtAction(nameof(GetItemChecklistById), new { id = itemChecklistDTO.Id }, itemChecklistDTO);
        }

        /// <summary>
        /// Atualiza um item do checklist existente pelo ID.
        /// </summary>
        /// <param name="id">O ID do item do checklist a ser atualizado.</param>
        /// <param name="itemChecklistDTO">Os dados atualizados do item do checklist.</param>
        /// <returns>Resposta HTTP com o status da operação.</returns>

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateItemChecklist(int id, [FromBody] ItemChecklistDTO itemChecklistDTO)
        {
            try
            {
                await _itemChecklistService.UpdateAsync(itemChecklistDTO, id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        /// <summary>
        /// Exclui um item do checklist específico pelo ID.
        /// </summary>
        /// <param name="id">O ID do item do checklist a ser excluído.</param>
        /// <returns>Resposta HTTP com o status da operação.</returns>

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteItemChecklist (int id)
        {
            await _itemChecklistService.DeleteAsync(id);
            return NoContent();
        }
    }
}
