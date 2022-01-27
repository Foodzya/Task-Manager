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
    public class TodolistRepository : ITodolistRepository
    {
        private readonly TaskManagerContext _context;

        public TodolistRepository(TaskManagerContext context)
        {
            _context = context;
        }

        public async Task AddAsync(TodoList todoList)
        {
            _context.TodoLists.Add(todoList);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int todoListId)
        {
            TodoList todoList = await _context.TodoLists.FirstOrDefaultAsync(todoList => todoList.Id == todoListId);

            if (todoList != null)
            {
                _context.TodoLists.Remove(todoList);

                await _context.SaveChangesAsync();
            }
            else
            {
                throw new NullReferenceException("TodoList with the specified ID is missing");
            }
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

        public async Task UpdateAsync(int todoListId, TodoList newTodoList)
        {
            TodoList todoList = await _context.TodoLists.FirstOrDefaultAsync(t => t.Id == todoListId);

            if (todoList != null)
            {
                todoList.Title = newTodoList.Title;

                await _context.SaveChangesAsync();
            }
            else 
            {
                throw new NullReferenceException("TodoList with the specified ID not found");
            }
        }
    }
}