using ChecklistApi.DTO_s;
using ChecklistApi.Models;

namespace ChecklistApi.Interfaces
{
    public interface IChecklistService
    {
        Task<ChecklistDTO> GetChecklistById(int id);
        Task<IEnumerable<ChecklistDTO>> GetAllChecklist();
        Task AddChecklist(Checklist checklistDTO);
        Task UpdateChecklist(ChecklistDTO checklistDTO, int id);
        Task DeleteChecklist(int id);
    }
}
