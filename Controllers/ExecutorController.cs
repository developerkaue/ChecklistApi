using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ChecklistApi.DTO_s;
using ChecklistApi.Data;
using ChecklistApi.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace ChecklistApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExecutorController : ControllerBase
    {
        private readonly IExecutorService _executorService;

        public ExecutorController(IExecutorService executorService)
        {
            _executorService = executorService;
        }

        /// <summary>
        /// Obtém um executor específico pelo seu ID.
        /// </summary>
        /// <param name="id">O ID do executor a ser obtido.</param>
        /// <returns>O executor correspondente ao ID fornecido.</returns>

        [HttpGet("{id}")]
        public async Task<ActionResult<ExecutorDTO>> GetExecutorById(int id)
        {
            var executor = await _executorService.GetExecutorById(id);

            if (executor == null)
            {
                return NotFound();
            }

            return Ok(executor);
        }

        /// <summary>
        /// Obtém todos os executores.
        /// </summary>
        /// <returns>Uma lista de todos os executores.</returns>

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExecutorDTO>>> GetAllExecutor()
        {
            var executor = await _executorService.GetAllAsync();
            return Ok(executor);
        }

        /// <summary>
        /// Adiciona um novo executor.
        /// </summary>
        /// <param name="executorDTO">Os dados do executor a ser adicionado.</param>
        /// <returns>O executor adicionado.</returns>

        [HttpPost]
        public async Task<ActionResult> AddExecutor([FromBody] ExecutorDTO executorDTO)
        {
            await _executorService.AddAsync(executorDTO);
            return CreatedAtAction(nameof(GetExecutorById), new { id = executorDTO.Id }, executorDTO);
        }

        /// <summary>
        /// Atualiza um executor existente pelo ID.
        /// </summary>
        /// <param name="id">O ID do executor a ser atualizado.</param>
        /// <param name="executorDTO">Os dados atualizados do executor.</param>
        /// <returns>Resposta HTTP com o status da operação.</returns>

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateExecutor(int id, [FromBody] ExecutorDTO executorDTO)
        {
            try
            {
                await _executorService.UpdateAsync(executorDTO, id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        /// <summary>
        /// Exclui um executor específico pelo ID.
        /// </summary>
        /// <param name="id">O ID do executor a ser excluído.</param>
        /// <returns>Resposta HTTP com o status da operação.</returns>

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteExecutor(int id)
        {
            await _executorService.DeleteAsync(id);
            return NoContent();
        }
    }
}
