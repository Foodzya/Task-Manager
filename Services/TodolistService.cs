using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Taskmanager.Data.Entities;
using Taskmanager.Repositories.Interfaces;
using Taskmanager.Services.Interfaces;

namespace Taskmanager.Services
{
    public class TodolistService : ITodolistService
    {
        private readonly ITodolistRepository _todolistRepository;
        private readonly ITodoitemRepository _todoitemRepository;

        public TodolistService(ITodolistRepository todolistRepository, ITodoitemRepository todoitemRepository)
        {
            _todolistRepository = todolistRepository;
            _todoitemRepository = todoitemRepository;
        }

        public async Task AddAsync(TodoList todolist, int userId)
        {
            todolist.CreationDate = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff");
            todolist.UserId = userId;

            await _todolistRepository.AddAsync(todolist);
        }

        public async Task DeleteAsync(int userId, int todolistId)
        {
            if (GetByIdAsync(todolistId) != null)
            {
                await _todolistRepository.DeleteAsync(userId, todolistId);
            }

            throw new Exception("Todolist not found");
        }

        public async Task<List<TodoList>> GetAllAsync(int userId)
        {
            return await _todolistRepository.GetAllAsync(userId);
        }

        public async Task<TodoList> GetByIdAsync(int todoListId)
        {
            return await _todolistRepository.GetByIdAsync(todoListId);
        }

        public async Task UpdateAsync(int todoListId, TodoList todoList)
        {
            await _todolistRepository.UpdateAsync(todoListId, todoList);
        }
    }
}