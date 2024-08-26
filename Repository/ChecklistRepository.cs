using ChecklistApi.Data;
using ChecklistApi.Interfaces;
using ChecklistApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
  
namespace ChecklistApi.Repository
{
    public class ChecklistRepository : IChecklistRepository
    {
        private readonly ApplicationDbContext _context;

        public ChecklistRepository(ApplicationDbContext context) { 
            _context = context;
        }

        public async Task<Checklist>GetByIdAsync(int id)
        {
            return await _context.Checklists.Include(c => c.Itens).FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Checklist>> GetAllAsync()
        {
            return await _context.Checklists.Include(c => c.Itens).ToListAsync();
        }
        public async Task AddAsync(Checklist checklist)
        {
            await _context.Checklists.AddAsync(checklist);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Checklist checklist)
        {
             _context.Checklists.Update(checklist);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id) {

            var checklist = _context.Checklists.FindAsync(id);
            _context.Remove(checklist);
            await _context.SaveChangesAsync();
      
        }

        public async Task ApproveOrRejectChecklist(int checklistId, bool aprovado, int supervisorId)
        {
            var checklist = await _context.Checklists.FindAsync(checklistId);
            if (checklist == null) throw new Exception("Checklist não encontrado");

            if (checklist.Aprovado.HasValue)
            {
                throw new Exception("Este checklist já foi finalizado e não pode ser alterado.");
            }

            checklist.SupervisorId = supervisorId;
            checklist.Aprovado = aprovado;

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Checklist>> GetAllLamb(Expression<Func<Checklist, bool>> predicate)
        {
            return await _context.Checklists.Where(predicate).ToListAsync();
        }
    }
}
