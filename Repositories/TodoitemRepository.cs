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

        public async Task AddAsync(int todolistId, TodoItem todoitem)
        {
            todoitem.TodoListId = todolistId;

            _context.TodoItems.Add(todoitem);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int todoitemId)
        {
            TodoItem deletableTodoitem = await _context.TodoItems.FirstOrDefaultAsync(item => item.Id == todoitemId);

            _context.TodoItems.Remove(deletableTodoitem);

            await _context.SaveChangesAsync();
        }

        public async Task<List<TodoItem>> GetAllAsync(int todoListId)
        {
            List<TodoItem> listOfTodoItems = await _context.TodoItems.Where(todoItem => todoItem.TodoListId == todoListId).ToListAsync();

            return listOfTodoItems;            
        }

        public async Task<TodoItem> GetByIdAsync(int todoitemId)
        {
            TodoItem requestedTodoitem = await _context.TodoItems.FirstOrDefaultAsync(todoitem => todoitem.Id == todoitemId);

            return requestedTodoitem;
        }

        public async Task UpdateAsync(int todoitemId, TodoItem item)
        {
            TodoItem updatableTodoitem = await _context.TodoItems.FirstOrDefaultAsync(item => item.Id == todoitemId);

            if (updatableTodoitem != null)
            {
                updatableTodoitem.IsFinished = item.IsFinished;
                updatableTodoitem.PriorityId = item.PriorityId;
                updatableTodoitem.Title = item.Title;
                updatableTodoitem.DeadlineDate = item.DeadlineDate;
            }

            await _context.SaveChangesAsync();
        }
    }
}