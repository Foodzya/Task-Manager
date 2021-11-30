using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Taskmanager.Data.Entities;
using Taskmanager.Repositories.Interfaces;
using Taskmanager.Services.Interfaces;

namespace Taskmanager.Services
{
    public class TodoitemService : ITodoitemService
    {
        private readonly ITodoitemRepository _todoitemRepo;

        public TodoitemService(ITodoitemRepository todoitemRepo)
        {
            _todoitemRepo = todoitemRepo;
        }

        public async Task AddAsync(Todoitem todoitem)
        {
            await _todoitemRepo.AddAsync(todoitem);
        }

        public async Task DeleteAsync(int userId, int listId, int itemId)
        {
            await _todoitemRepo.DeleteAsync(userId, listId, itemId);
        }

        public async Task<List<Todoitem>> GetAllAsync(int userId, int todolistId)
        {
           return await  _todoitemRepo.GetAllAsync(userId, todolistId);
        }

        public async Task<Todoitem> GetOneByIdAsync(int userId, int listId, int itemId)
        {
            return await _todoitemRepo.GetOneByIdAsync(userId, listId, itemId); 
        }

        public async Task UpdateAsync(int userId, int listId, int itemId, Todoitem todoitem)
        {
            await _todoitemRepo.UpdateAsync(userId, listId, itemId, todoitem);
        }
    }
}