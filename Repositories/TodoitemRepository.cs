using System.Collections.Generic;
using System.Linq;
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

        public async Task AddAsync(Todoitem todoitem)
        {
            await _context.Todoitems.AddAsync(todoitem);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Todoitem todoitem)
        {
            _context.Todoitems.Remove(todoitem);

            await _context.SaveChangesAsync();
        }

        public async Task<List<Todoitem>> GetAllAsync()
        {
            return await _context.Todoitems.ToListAsync();
        }

        public Task<Todoitem> GetOneByIdAsync(int id)
        {
            return _context.Todoitems.FirstAsync(t => t.Id == id);
        }

        public async Task UpdateAsync(Todoitem updatedTodoitem)
        {
            Todoitem updatableTodoitem = await _context.Todoitems.FirstOrDefaultAsync(t => t.Id.Equals(updatedTodoitem.Id));

            if (updatableTodoitem != null)
            {
                updatableTodoitem.Isfinished = updatedTodoitem.Isfinished;
                updatableTodoitem.Note = updatedTodoitem.Note;
                updatableTodoitem.Priority = updatedTodoitem.Priority;
                updatableTodoitem.Priorityid = updatedTodoitem.Priorityid;
                updatableTodoitem.Title = updatedTodoitem.Title;
                updatableTodoitem.Deadlinedate = updatedTodoitem.Deadlinedate;
            }

            await _context.SaveChangesAsync();
        }
    }
}