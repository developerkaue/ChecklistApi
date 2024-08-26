using ChecklistApi.DTO_s;
using ChecklistApi.Models;

namespace ChecklistApi.Interfaces
{
    public interface IItemChecklistRepository
    {
        Task<ItemChecklist> GetItemChecklistById(int id);
        Task<IEnumerable<ItemChecklist>> GetAllAsync();
        Task AddAsync(ItemChecklist itemChecklist);
        Task UpdateAsync(ItemChecklist itemChecklist);
        Task DeleteAsync(int id);
    }
}
