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

        [Authorize]
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

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExecutorDTO>>> GetAllExecutor()
        {
            var executor = await _executorService.GetAllAsync();
            return Ok(executor);
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> AddExecutor([FromBody] ExecutorDTO executorDTO)
        {
            await _executorService.AddAsync(executorDTO);
            return CreatedAtAction(nameof(GetExecutorById), new { id = executorDTO.Id }, executorDTO);
        }

        [Authorize]
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

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteExecutor(int id)
        {
            await _executorService.DeleteAsync(id);
            return NoContent();
        }
    }
}
