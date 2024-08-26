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

    /// <summary>
    /// Obtém um veículo específico pelo seu ID.
    /// </summary>
    /// <param name="id">O ID do veículo a ser obtido.</param>
    /// <returns>O veículo correspondente ao ID fornecido.</returns>
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

    /// <summary>
    /// Obtém todos os veículos.
    /// </summary>
    /// <returns>Uma lista de todos os veículos.</returns>
    [Authorize]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<VeiculoDTO>>> GetAllVeiculos()
    {
        var veiculos = await _veiculoService.GetAllVeiculos();
        return Ok(veiculos);
    }

    /// <summary>
    /// Adiciona um novo veículo.
    /// </summary>
    /// <param name="veiculoDTO">Os dados do veículo a ser adicionado.</param>
    /// <returns>O veículo adicionado.</returns>
    [Authorize]
    [HttpPost]
    public async Task<ActionResult> AddVeiculo([FromBody] VeiculoDTO veiculoDTO)
    {
        await _veiculoService.AddVeiculo(veiculoDTO);
        return CreatedAtAction(nameof(GetVeiculoById), new { id = veiculoDTO.Id }, veiculoDTO);
    }

    /// <summary>
    /// Atualiza um veículo existente pelo ID.
    /// </summary>
    /// <param name="id">O ID do veículo a ser atualizado.</param>
    /// <param name="veiculoDTO">Os dados atualizados do veículo.</param>
    /// <returns>Resposta HTTP com o status da operação.</returns>
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

    /// <summary>
    /// Exclui um veículo específico pelo ID.
    /// </summary>
    /// <param name="id">O ID do veículo a ser excluído.</param>
    /// <returns>Resposta HTTP com o status da operação.</returns>
    [Authorize]
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteVeiculo(int id)
    {
        await _veiculoService.DeleteVeiculo(id);
        return NoContent();
    }
}
