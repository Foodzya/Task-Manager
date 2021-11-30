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

        public async Task DeleteAsync(int userId, int listId, int itemId)
        {
            Todolist requiredTodolist = await _context.Todolists.FirstOrDefaultAsync(list => list.Id == listId && list.Userid == userId);

            requiredTodolist.Todoitems.Remove(requiredTodolist.Todoitems.FirstOrDefault(item => item.Id == itemId));

            await _context.SaveChangesAsync();
        }

        public async Task<List<Todoitem>> GetAllAsync(int userId, int listId)
        {
            Todolist requiredTodolist = await _context.Todolists.FirstOrDefaultAsync(list => list.Id == listId && list.Userid == userId);

            return requiredTodolist.Todoitems.ToList();
        }

        public async Task<Todoitem> GetOneByIdAsync(int userId, int listId, int itemId)
        {
            int requiredTodolistId = _context.Todolists.FirstAsync(list => list.Id == listId && list.Userid == userId).Id;

            return await _context.Todoitems.FirstOrDefaultAsync(item => item.Id == itemId && item.Todolistid == requiredTodolistId);
        }

        public async Task UpdateAsync(int userId, int listId, int itemId, Todoitem item)
        {
            Todolist todolist = await _context.Todolists.FirstOrDefaultAsync(list => list.Id == listId && list.Userid == userId);

            Todoitem updatableTodoitem = todolist.Todoitems.FirstOrDefault(item => item.Id == itemId);

            if (updatableTodoitem != null)
            {
                updatableTodoitem.Isfinished = item.Isfinished;
                updatableTodoitem.Note = item.Note;
                updatableTodoitem.Priority = item.Priority;
                updatableTodoitem.Priorityid = item.Priorityid;
                updatableTodoitem.Title = item.Title;
                updatableTodoitem.Deadlinedate = item.Deadlinedate;
            }

            await _context.SaveChangesAsync();
        }
    }
}