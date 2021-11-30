using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Taskmanager.Data.Entities;

namespace Taskmanager.Services.Interfaces
{
    public interface ITodoitemService
    {
        public Task AddAsync(Todoitem todoitem);
        public Task DeleteAsync(int userId, int listId, int itemId);
        public Task<List<Todoitem>> GetAllAsync(int userId, int todolistId);
        public Task UpdateAsync (int userId, int listId, int itemId, Todoitem todoitem);
        public Task<Todoitem> GetOneByIdAsync(int userId, int listId, int itemId); 
    }
}