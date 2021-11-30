using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taskmanager.Data.Entities;
using Taskmanager.Repositories.Interfaces;
using Taskmanager.Services.Interfaces;

namespace Taskmanager.Services
{
    public class TodolistService : ITodolistService
    {
        private readonly ITodolistRepository _todolistRepo;
        private readonly ITodoitemRepository _todoitemRepo;

        public TodolistService(ITodolistRepository todolistRepo, ITodoitemRepository todoitemRepo)
        {
            _todolistRepo = todolistRepo;
            _todoitemRepo = todoitemRepo;
        }

        public async Task AddAsync(Todolist todolist, int userId)
        {
            todolist.Creationdate = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff");
            todolist.Userid = userId;

            await _todolistRepo.AddAsync(todolist);
        }

        public async Task DeleteAsync(int userId, int todolistId)
        {
            if (GetOneByIdAsync(todolistId, userId) != null)
            {
                await _todolistRepo.DeleteAsync(userId, todolistId);
            }

            throw new Exception("Todolist not found");
        }

        public async Task<List<Todolist>> GetAllAsync(int userId)
        {
            return await _todolistRepo.GetAllAsync(userId);
        }

        public async Task<Todolist> GetOneByIdAsync(int listId, int userId)
        {
            return await _todolistRepo.GetOneByIdAsync(listId, userId);
        }

        public async Task UpdateAsync(int userId, int updatableTodolist, Todolist updatedTodolist)
        {
            await _todolistRepo.UpdateAsync(userId, updatableTodolist, updatedTodolist);
        }
    }
}