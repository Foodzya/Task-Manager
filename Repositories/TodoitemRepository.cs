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

        public async Task AddAsync(int todolistId, Todoitem todoitem)
        {
            todoitem.Todolistid = todolistId;

            _context.Todoitems.Add(todoitem);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int todoitemId)
        {
            Todoitem deletableTodoitem = await _context.Todoitems.FirstOrDefaultAsync(item => item.Id == todoitemId);

            _context.Todoitems.Remove(deletableTodoitem);

            await _context.SaveChangesAsync();
        }

        public async Task<List<Todoitem>> GetAllAsync(int userId, int listId)
        {
            Todolist requiredTodolist = await _context.Todolists.FirstOrDefaultAsync(list => list.Id == listId && list.Userid == userId);

            return requiredTodolist.Todoitems.ToList();
        }

        public async Task<Todoitem> GetByIdAsync(int todoitemId)
        {
            Todoitem requestedTodoitem = await _context.Todoitems.FirstOrDefaultAsync(todoitem => todoitem.Id == todoitemId);

            return requestedTodoitem;
        }

        public async Task UpdateAsync(int todoitemId, Todoitem item)
        {
            Todoitem updatableTodoitem = await _context.Todoitems.FirstOrDefaultAsync(item => item.Id == todoitemId);

            if (updatableTodoitem != null)
            {
                updatableTodoitem.Isfinished = item.Isfinished;
                updatableTodoitem.Priorityid = item.Priorityid;
                updatableTodoitem.Title = item.Title;
                updatableTodoitem.Deadlinedate = item.Deadlinedate;
            }

            await _context.SaveChangesAsync();
        }
    }
}