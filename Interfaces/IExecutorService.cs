using ChecklistApi.DTO_s;
using ChecklistApi.Models;

namespace ChecklistApi.Interfaces
{
    public interface IExecutorService 
    {
        Task<ExecutorDTO> GetExecutorById(int id);
        Task<IEnumerable<ExecutorDTO>> GetAllAsync();
        Task AddAsync(ExecutorDTO executorDTO);
        Task UpdateAsync(ExecutorDTO executorDTO, int id);
        Task DeleteAsync(int id);
    }
}
