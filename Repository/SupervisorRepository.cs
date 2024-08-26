using ChecklistApi.Data;
using ChecklistApi.Interfaces;
using ChecklistApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ChecklistApi.Repository
{
    public class SupervisorRepository : ISupervisorRepository
    {
        private readonly ApplicationDbContext _context;

        public SupervisorRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Supervisor> GetSupervisorById(int id)
        {
            return await _context.Supervisores.FindAsync(id);
        }
        public async Task<IEnumerable<Supervisor>> GetAllAsync()
        {
            return await _context.Supervisores.ToListAsync();
        }


        public async Task AddAsync(Supervisor supervisor)
        {
            await _context.Supervisores.AddAsync(supervisor);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Supervisor supervisor)
        {
             _context.Supervisores.Update(supervisor);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var supervisor = await _context.Supervisores.FindAsync(id);
            if (supervisor != null)
            {
                _context.Supervisores.Remove(supervisor);
                await _context.SaveChangesAsync();
            }
        }
    }
}
