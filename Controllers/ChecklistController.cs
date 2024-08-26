using Microsoft.AspNetCore.Mvc;
using ChecklistApi.DTO_s;
using ChecklistApi.Interfaces;
using System.Runtime.CompilerServices;
using AutoMapper;
using ChecklistApi.Models;
using Microsoft.AspNetCore.Authorization;

[Route("api/[controller]")]
[ApiController]

public class ChecklistController : ControllerBase
{
    private readonly IChecklistService _checklistService;
    private readonly IMapper _mapper;

    public ChecklistController(IChecklistService checklistService, IMapper mapper)
    {
        _checklistService = checklistService;
        _mapper = mapper;
    }

    /// <summary>
    /// Obtém um checklist específico pelo seu ID.
    /// </summary>
    /// <param name="id">O ID do checklist a ser obtido.</param>
    /// <returns>O checklist correspondente ao ID fornecido.</returns>

    [HttpGet("{id}")]
    public async Task<ActionResult<ChecklistDTO>> GetChecklistById(int id)
    {

        var checklist = await _checklistService.GetChecklistById(id);
        if (checklist == null)
        {
            return NotFound();
        }
        return Ok(checklist);
    }

    /// <summary>
    /// Obtém todos os checklists.
    /// </summary>
    /// <returns>Uma lista de todos os checklists.</returns>

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ChecklistDTO>>> GetAllChecklist()
    {
        var checklist = await _checklistService.GetAllChecklist();
        return Ok(checklist);
    }

    /// <summary>
    /// Adiciona um novo checklist.
    /// </summary>
    /// <param name="checklistDTO">Os dados do checklist a ser adicionado.</param>
    /// <returns>O checklist adicionado.</returns>

    [HttpPost]
    public async Task<ActionResult<ChecklistDTO>> AddChecklist([FromBody] ChecklistDTO checklistDTO)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var checklist = _mapper.Map<Checklist>(checklistDTO);
        await _checklistService.AddChecklist(checklist);
        return CreatedAtAction(nameof(GetChecklistById), new { id = checklist.Id }, checklistDTO);
    }

    /// <summary>
    /// Atualiza um checklist existente pelo ID.
    /// </summary>
    /// <param name="id">O ID do checklist a ser atualizado.</param>
    /// <param name="checklistDTO">Os dados atualizados do checklist.</param>
    /// <returns>Resposta HTTP com o status da operação.</returns>

    [HttpPut("{id}")]
    public async Task<ActionResult<ChecklistDTO>> UpdateChecklist(int id, [FromBody] ChecklistDTO checklistDTO)
    {
        try {
            await _checklistService.UpdateChecklist(checklistDTO, id);
            return NoContent();
        }
        catch (Exception ex){ 
            return NotFound(ex.Message);
        }
        
    }

    /// <summary>
    /// Exclui um checklist específico pelo ID.
    /// </summary>
    /// <param name="id">O ID do checklist a ser excluído.</param>
    /// <returns>Resposta HTTP com o status da operação.</returns>

    [HttpDelete("{id}")]

    public async Task<ActionResult<ChecklistDTO>> DeleteChecklist (int id)
    {
        await _checklistService.DeleteChecklist(id);
        return NoContent();
    }
}

