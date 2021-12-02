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

        public async Task AddAsync(Todolist todolist, int userId)
        {
            todolist.Creationdate = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff");
            todolist.Userid = userId;

            await _todolistRepository.AddAsync(todolist);
        }

        public async Task DeleteAsync(int userId, int todolistId)
        {
            if (GetByIdAsync(todolistId, userId) != null)
            {
                await _todolistRepository.DeleteAsync(userId, todolistId);
            }

            throw new Exception("Todolist not found");
        }

        public async Task<List<Todolist>> GetAllAsync(int userId)
        {
            return await _todolistRepository.GetAllAsync(userId);
        }

        public async Task<Todolist> GetByIdAsync(int listId, int userId)
        {
            return await _todolistRepository.GetByIdAsync(listId, userId);
        }

        public async Task UpdateAsync(int userId, int updatableTodolist, Todolist updatedTodolist)
        {
            await _todolistRepository.UpdateAsync(userId, updatableTodolist, updatedTodolist);
        }
    }
}