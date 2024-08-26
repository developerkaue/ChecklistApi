using Microsoft.AspNetCore.Mvc;
using ChecklistApi.DTO_s;
using Microsoft.AspNetCore.Authorization;

[Route("api/[controller]")]
[ApiController]
public class VeiculoController : ControllerBase
{
    private readonly IVeiculoService _veiculoService;

    public VeiculoController(IVeiculoService veiculoService)
    {
        _veiculoService = veiculoService;
    }

    [Authorize]
    [HttpGet("{id}")]
    public async Task<ActionResult<VeiculoDTO>> GetVeiculoById(int id)
    {
        var veiculo = await _veiculoService.GetVeiculoById(id);
        if (veiculo == null)
        {
            return NotFound();
        }
        return Ok(veiculo);
    }

    [Authorize]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<VeiculoDTO>>> GetAllVeiculos()
    {
        var veiculos = await _veiculoService.GetAllVeiculos();
        return Ok(veiculos);
    }

    [Authorize]
    [HttpPost]
    public async Task<ActionResult> AddVeiculo([FromBody] VeiculoDTO veiculoDTO)
    {
        await _veiculoService.AddVeiculo(veiculoDTO);
        return CreatedAtAction(nameof(GetVeiculoById), new { id = veiculoDTO.Id }, veiculoDTO);
    }

    [Authorize]
    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateVeiculo(int id, [FromBody] VeiculoDTO veiculoDTO)
    {
        try
        {
            await _veiculoService.UpdateVeiculo(id, veiculoDTO);
            return NoContent();
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }

    [Authorize]
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteVeiculo(int id)
    {
        await _veiculoService.DeleteVeiculo(id);
        return NoContent();
    }
}
