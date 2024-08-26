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

        [Authorize]
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

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemChecklistDTO>>> GertAllItemChecklist()
        {
            var itemChecklist = await _itemChecklistService.GetAllAsync();
            return Ok(itemChecklist);
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> AddItemChecklist([FromBody] ItemChecklistDTO itemChecklistDTO)
        {
            await _itemChecklistService.AddAsync(itemChecklistDTO);
            return CreatedAtAction(nameof(GetItemChecklistById), new { id = itemChecklistDTO.Id }, itemChecklistDTO);
        }

        [Authorize]
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

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteItemChecklist (int id)
        {
            await _itemChecklistService.DeleteAsync(id);
            return NoContent();
        }
    }
}
