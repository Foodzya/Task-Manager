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

        public async Task AddAsync(Todolist todolist)
        {
            await _todolistRepo.AddAsync(todolist);
        }

        public async Task DeleteAsync(Todolist todolist)
        {
            if(todolist != null) 
            {
                await _todolistRepo.DeleteAsync(todolist);
            }
        }

        public async Task<List<Todolist>> GetAllAsync()
        {
            return await _todolistRepo.GetAllAsync();
        }

        public async Task<Todolist> GetOneByIdAsync(int listId, int userId)
        {
            return await _todolistRepo.GetOneByIdAsync(listId, userId);
        }

        public Task UpdateAsync(int updatableTodolist, Todolist updatedTodolist)
        {
            throw new System.NotImplementedException();
        }
    }
}