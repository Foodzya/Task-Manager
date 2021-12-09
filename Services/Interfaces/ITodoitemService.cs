using System.Collections.Generic;
using System.Threading.Tasks;
using Taskmanager.Data.Entities;

namespace Taskmanager.Services.Interfaces
{
    public interface ITodoitemService
    {
        public Task AddAsync(int todolistId, TodoItem todoitem);
        public Task DeleteAsync(int todoitemId);
        public Task<List<TodoItem>> GetAllAsync(int todoListId);
        public Task UpdateAsync (int todoitemId, TodoItem todoitem);
        public Task<TodoItem> GetByIdAsync(int todoitemId); 
    }
}