using System;
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

        public async Task AddAsync(int todoListId, TodoItem todoItem)
        {
            todoItem.TodoListId = todoListId;

            _context.TodoItems.Add(todoItem);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int todoItemId)
        {
            TodoItem todoItem = await _context.TodoItems.FirstOrDefaultAsync(todoItem => todoItem.Id == todoItemId);

            if (todoItem != null)
            {
                _context.TodoItems.Remove(todoItem);

                await _context.SaveChangesAsync();
            }
            else 
            {
                throw new NullReferenceException("TodoItem with the specified ID not found");
            }      
        }

        public async Task<List<TodoItem>> GetAllAsync(int todoListId)
        {
            List<TodoItem> todoItems = await _context.TodoItems.Where(todoItem => todoItem.TodoListId == todoListId).ToListAsync();

            return todoItems;            
        }

        public async Task<TodoItem> GetByIdAsync(int todoItemId)
        {
            TodoItem todoItem = await _context.TodoItems.FirstOrDefaultAsync(todoItem => todoItem.Id == todoItemId);

            return todoItem;
        }

        public async Task UpdateAsync(int todoItemId, TodoItem newTodoItem)
        {
            TodoItem todoItem = await _context.TodoItems.FirstOrDefaultAsync(item => item.Id == todoItemId);

            if (todoItem != null)
            {
                todoItem.IsFinished = newTodoItem.IsFinished;
                todoItem.PriorityId = newTodoItem.PriorityId;
                todoItem.Title = newTodoItem.Title;
                todoItem.DeadlineDate = newTodoItem.DeadlineDate;

                await _context.SaveChangesAsync();
            }
            else 
            {
                throw new NullReferenceException("TodoItem with the specified ID not found");
            }
        }
    }
}