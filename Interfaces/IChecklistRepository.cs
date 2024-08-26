using ChecklistApi.Models;
using System.ComponentModel;
using System.Linq.Expressions;

namespace ChecklistApi.Interfaces
{
    public interface IChecklistRepository
    {
        Task<Checklist> GetByIdAsync(int id);
        Task<IEnumerable<Checklist>> GetAllAsync();
        Task<IEnumerable<Checklist>> GetAllLamb(Expression<Func<Checklist, bool>> predicate);
        Task AddAsync(Checklist checklist);
        Task UpdateAsync(Checklist checklist);
        Task DeleteAsync(int id);
        Task ApproveOrRejectChecklist(int checklistId, bool aprovado, int supervisorId);

    }
}
