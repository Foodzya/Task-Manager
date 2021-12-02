using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Taskmanager.Data.Context;
using Taskmanager.Data.Entities;
using Taskmanager.Repositories.Interfaces;

namespace Taskmanager.Repositories
{
    public class PriorityRepository : IPriorityRepository
    {
        private readonly TaskManagerContext _context;

        public PriorityRepository(TaskManagerContext context)
        {
            _context = context;
        }

        public async Task<List<Priority>> GetAllAsync()
        {
            return await _context.Priorities.ToListAsync();
        }

        public async Task<Priority> GetByIdAsync(int id)
        {
            return await _context.Priorities.FirstAsync(p => p.Id == id);
        }
    }
}