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

        public async Task AddAsync(TodoList todolist)
        {
            _context.TodoLists.Add(todolist);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int userId, int todolistId)
        {
            TodoList deletableTodolist = await _context.TodoLists.FirstAsync(list => list.UserId == userId && list.Id == todolistId);

            _context.TodoLists.Remove(deletableTodolist);

            await _context.SaveChangesAsync();
        }

        public async Task<List<TodoList>> GetAllAsync(int userId)
        {
            return await _context.TodoLists.Where(list => list.UserId == userId).ToListAsync();
        }

        public async Task<TodoList> GetByIdAsync(int todoListId)
        {
            TodoList todoList = await _context.TodoLists.FirstOrDefaultAsync(todoList => todoList.Id == todoListId);

            return todoList;
        }

        public async Task UpdateAsync(int todoListId, TodoList todoList)
        {
            TodoList todolistToBeUpdated = await _context.TodoLists.FirstOrDefaultAsync(list => list.Id == todoListId);

            if (todolistToBeUpdated != null)
            {
                todolistToBeUpdated.Title = todoList.Title;
            }

            await _context.SaveChangesAsync();
        }
    }
}