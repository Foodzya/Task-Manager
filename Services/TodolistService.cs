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
        private readonly ITodolistRepository _todoListRepository;

        public TodolistService(ITodolistRepository todoListRepository)
        {
            _todoListRepository = todoListRepository;
        }

        public async Task AddAsync(TodoList todoList, int userId)
        {
            todoList.CreationDate = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff");
            todoList.UserId = userId;

            await _todoListRepository.AddAsync(todoList);
        }

        public async Task DeleteAsync(int todoListId)
        {
            if (GetByIdAsync(todoListId).Result != null)
            {
                await _todoListRepository.DeleteAsync(todoListId);
            }
            else
            {
                throw new Exception("TodoList with the specified ID is missing");
            }
        }

        public async Task<List<TodoList>> GetAllAsync(int userId)
        {
            return await _todoListRepository.GetAllAsync(userId);
        }

        public async Task<TodoList> GetByIdAsync(int todoListId)
        {
            return await _todoListRepository.GetByIdAsync(todoListId);
        }

        public async Task UpdateAsync(int todoListId, TodoList todoList)
        {
            await _todoListRepository.UpdateAsync(todoListId, todoList);
        }
    }
}