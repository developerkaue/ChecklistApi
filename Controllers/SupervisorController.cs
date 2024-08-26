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

    /// <summary>
    /// Obtém um supervisor específico pelo seu ID.
    /// </summary>
    /// <param name="id">O ID do supervisor a ser obtido.</param>
    /// <returns>O supervisor correspondente ao ID fornecido.</returns>

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

    /// <summary>
    /// Obtém todos os supervisores.
    /// </summary>
    /// <returns>Uma lista de todos os supervisores.</returns>

    [HttpGet]
    public async Task<ActionResult<IEnumerable<SupervisorDTO>>> GetAllSupervisor()
    {
        var supervisor = await _supervisorService.GetAllAsync();
        return Ok(supervisor);
    }

    /// <summary>
    /// Adiciona um novo supervisor.
    /// </summary>
    /// <param name="supervisorDTO">Os dados do supervisor a ser adicionado.</param>
    /// <returns>O supervisor adicionado.</returns>

    [HttpPost]
    public async Task<ActionResult> AddSupervisor([FromBody] SupervisorDTO supervisorDTO)
    {
        await _supervisorService.AddAsync(supervisorDTO);
        return CreatedAtAction(nameof(GetSupervisorById), new { id = supervisorDTO.Id }, supervisorDTO);
    }

    /// <summary>
    /// Atualiza um supervisor existente pelo ID.
    /// </summary>
    /// <param name="id">O ID do supervisor a ser atualizado.</param>
    /// <param name="supervisorDTO">Os dados atualizados do supervisor.</param>
    /// <returns>Resposta HTTP com o status da operação.</returns>

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

    /// <summary>
    /// Exclui um supervisor específico pelo ID.
    /// </summary>
    /// <param name="id">O ID do supervisor a ser excluído.</param>
    /// <returns>Resposta HTTP com o status da operação.</returns>

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteSupervisor(int id)
    {
        await _supervisorService.DeleteAsync(id);
        return NoContent();
    }
}
