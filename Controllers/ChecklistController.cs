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

    [Authorize]
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

    [Authorize]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ChecklistDTO>>> GetAllChecklist()
    {
        var checklist = await _checklistService.GetAllChecklist();
        return Ok(checklist);
    }

    [Authorize]
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

    [Authorize]
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

    [Authorize]
    [HttpDelete("{id}")]

    public async Task<ActionResult<ChecklistDTO>> DeleteChecklist (int id)
    {
        await _checklistService.DeleteChecklist(id);
        return NoContent();
    }
}

