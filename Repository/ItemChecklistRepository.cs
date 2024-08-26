using ChecklistApi.Data;
using ChecklistApi.Interfaces;
using ChecklistApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace ChecklistApi.Repository
{
    public class ItemChecklistRepository : IItemChecklistRepository
    {
        private readonly ApplicationDbContext _context;
        public ItemChecklistRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ItemChecklist> GetItemChecklistById(int id)
        {
            return await _context.ItensChecklist.FindAsync(id);
        }

        public async Task<IEnumerable<ItemChecklist>> GetAllAsync()
        {
            return await _context.ItensChecklist.ToListAsync();
        }

        public async Task AddAsync(ItemChecklist itemChecklist)
        {
            await _context.ItensChecklist.AddAsync(itemChecklist);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ItemChecklist itemChecklist)
        {
            _context.ItensChecklist.Update(itemChecklist);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var itemChecklist = await _context.ItensChecklist.FindAsync(id);
            if (itemChecklist != null)
            {
                _context.Remove(itemChecklist);
            }
            await _context.SaveChangesAsync();
        }
    }
}
