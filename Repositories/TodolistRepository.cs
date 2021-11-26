using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Taskmanager.Data.Context;
using Taskmanager.Data.Entities;
using Taskmanager.Repositories.Interfaces;

namespace Taskmanager.Repositories
{
    public class TodolistRepository : ITodolistRepository
    {
        private readonly TaskManagerContext _context;

        public TodolistRepository(TaskManagerContext context)
        {
            _context = context;
        }

        public async Task Add(Todolist todolist)
        {
            await _context.Todolists.AddAsync(todolist);

            await _context.SaveChangesAsync();
        }

        public async Task Delete(Todolist todolist)
        {
            _context.Todolists.Remove(todolist);

            await _context.SaveChangesAsync();
        }

        public async Task<List<Todolist>> GetAll()
        {
            return await _context.Todolists.ToListAsync();
        }

        public async Task<Todolist> GetOneById(int id)
        {
            return await _context.Todolists.FirstAsync(t => t.Id == id);
        }

        public Task Update(Todolist todolist)
        {
            throw new System.NotImplementedException();
        }
    }
}