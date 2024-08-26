using ChecklistApi.DTO_s;
using ChecklistApi.Models;

namespace ChecklistApi.Interfaces
{
    public interface IExecutorRepository
    {
        Task<Executor> GetExecutorById(int id);
        Task<IEnumerable<Executor>> GetAllAsync();
        Task AddAsync(Executor executor);
        Task UpdateAsync(Executor executor);
        Task DeleteAsync(int id);
    }
}
