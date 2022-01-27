using System.Collections.Generic;
using System.Threading.Tasks;
using Taskmanager.Data.Entities;

namespace Taskmanager.Repositories.Interfaces
{
    public interface ITodolistRepository
    {
        public Task<TodoList> GetByIdAsync(int todoListId);
        public Task<List<TodoList>> GetAllAsync(int userId);
        public Task AddAsync(TodoList todoList);
        public Task UpdateAsync(int todoListId, TodoList todoList);
        public Task DeleteAsync(int todoListId);
    }
}