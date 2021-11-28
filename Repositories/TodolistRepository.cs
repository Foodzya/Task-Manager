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

        public async Task AddAsync(Todolist todolist)
        {
            await _context.Todolists.AddAsync(todolist);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Todolist todolist)
        {
            _context.Todolists.Remove(todolist);

            await _context.SaveChangesAsync();
        }

        public async Task<List<Todolist>> GetAllAsync()
        {
            return await _context.Todolists.ToListAsync();
        }

        public async Task<Todolist> GetOneByIdAsync(int listId, int userId)
        {
            Todolist list = await _context.Todolists.Where(list => list.Userid == userId).SingleAsync(list => list.Id == listId);

            return await _context.Todolists.FirstAsync(t => t.Id == listId);
        }

        public async Task UpdateAsync(int idOfUpdatableTodolist, Todolist updatedTodolist)
        {
            Todolist todolistToBeUpdated = await _context.Todolists.FirstOrDefaultAsync(t => t.Id == idOfUpdatableTodolist);

            if (todolistToBeUpdated != null)
            {
                todolistToBeUpdated.Title = updatedTodolist.Title;
            }

            await _context.SaveChangesAsync();
        }
    }
}