using ChecklistApi.DTO_s;
using ChecklistApi.Models;

namespace ChecklistApi.Interfaces
{
    public interface ISupervisorService
    {
        Task<SupervisorDTO> GetSupervisorById(int id);
        Task<IEnumerable<SupervisorDTO>> GetAllAsync();
        Task AddAsync(SupervisorDTO supervisorDTO);
        Task UpdateAsync(SupervisorDTO supervisorDTO, int id);
        Task DeleteAsync(int id);
    }
}
