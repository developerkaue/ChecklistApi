using ChecklistApi.DTO_s;
using ChecklistApi.Models;

namespace ChecklistApi.Interfaces
{
    public interface IItemChecklistService
    {
        Task<ItemChecklistDTO> GetItemChecklistById(int id);
        Task<IEnumerable<ItemChecklistDTO>> GetAllAsync();
        Task AddAsync(ItemChecklistDTO itemChecklistDTO);
        Task UpdateAsync(ItemChecklistDTO itemChecklistDTO, int id);
        Task DeleteAsync(int id);
    }
}
