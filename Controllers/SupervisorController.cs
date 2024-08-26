using Microsoft.AspNetCore.Mvc;
using ChecklistApi.DTO_s;
using ChecklistApi.Interfaces;
using Microsoft.AspNetCore.Authorization;

[Route("api/[controller]")]
[ApiController]
public class SupervisorController : ControllerBase
{
    private readonly ISupervisorService _supervisorService;

    public SupervisorController(ISupervisorService supervisorService)
    {
        _supervisorService = supervisorService;
    }

    [Authorize]
    [HttpGet("{id}")]
    public async Task<ActionResult<SupervisorDTO>> GetSupervisorById(int id)
    {
        var supervisor = await _supervisorService.GetSupervisorById(id);
        if (supervisor == null)
        {
            return NotFound();
        }
        return Ok(supervisor);
    }

    [Authorize]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<SupervisorDTO>>> GetAllSupervisor()
    {
        var supervisor = await _supervisorService.GetAllAsync();
        return Ok(supervisor);
    }

    [Authorize]
    [HttpPost]
    public async Task<ActionResult> AddSupervisor([FromBody] SupervisorDTO supervisorDTO)
    {
        await _supervisorService.AddAsync(supervisorDTO);
        return CreatedAtAction(nameof(GetSupervisorById), new { id = supervisorDTO.Id }, supervisorDTO);
    }

    [Authorize]
    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateSupervisor(int id, [FromBody] SupervisorDTO supervisorDTO)
    {
        try
        {
            await _supervisorService.UpdateAsync(supervisorDTO,id);
            return NoContent();
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }

    [Authorize]
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteSupervisor(int id)
    {
        await _supervisorService.DeleteAsync(id);
        return NoContent();
    }
}
