using System.Collections.Generic;
using System.Threading.Tasks;
using Taskmanager.Data.Entities;

namespace Taskmanager.Services.Interfaces
{
    public interface ITodoitemService
    {
        public Task AddAsync(int todoListId, TodoItem todoItem);
        public Task DeleteAsync(int todoItemId);
        public Task<List<TodoItem>> GetAllAsync(int todoListId);
        public Task UpdateAsync (int todoItemId, TodoItem todoItem);
        public Task<TodoItem> GetByIdAsync(int todoItemId); 
    }
}