using ChecklistApi.Data;
using ChecklistApi.Interfaces;
using ChecklistApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace ChecklistApi.Repository
{
    public class ExecutorRepository : IExecutorRepository
    {
        private readonly ApplicationDbContext _context;
        public ExecutorRepository(ApplicationDbContext context) {
            _context = context;
        }

        public async Task<Executor> GetExecutorById(int id)
        {
            return await _context.Executores.FindAsync(id);
        } 

        public async Task<IEnumerable<Executor>> GetAllAsync()
        {
            return await _context.Executores.ToListAsync();
        }

        public async Task AddAsync(Executor executor)
        {
            await _context.Executores.AddAsync(executor);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Executor executor)
        {
            _context.Executores.Update(executor);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var executor = await _context.Executores.FindAsync(id);
            if (executor != null)
            {
                _context.Remove(executor);
            }
            await _context.SaveChangesAsync();
        }
    }
}
