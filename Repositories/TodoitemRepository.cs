using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Taskmanager.Data.Context;
using Taskmanager.Data.Entities;
using Taskmanager.Repositories.Interfaces;

namespace Taskmanager.Repositories
{
    public class TodoitemRepository : ITodoitemRepository
    {
        private readonly TaskManagerContext _context;

        public TodoitemRepository(TaskManagerContext context)
        {
            _context = context;
        }

        public async Task Add(Todoitem todoitem)
        {
            await _context.Todoitems.AddAsync(todoitem);

            await _context.SaveChangesAsync();
        }

        public async Task Delete(Todoitem todoitem)
        {
            _context.Todoitems.Remove(todoitem);

            await _context.SaveChangesAsync();
        }

        public async Task<List<Todoitem>> GetAll()
        {
            return await _context.Todoitems.ToListAsync();
        }

        public Task<Todoitem> GetOneById(int id)
        {
            return _context.Todoitems.FirstAsync(t => t.Id == id);
        }

        public Task Update(Todoitem todoitem)
        {
            throw new System.NotImplementedException();
        }
    }
}