using ChecklistApi.Models;

namespace ChecklistApi.Interfaces
{
    public interface ISupervisorRepository
    {
        Task<Supervisor> GetSupervisorById(int id);
        Task<IEnumerable<Supervisor>> GetAllAsync();
        Task AddAsync(Supervisor supervisor);
        Task UpdateAsync(Supervisor supervisor);
        Task DeleteAsync(int id);
    }
}
