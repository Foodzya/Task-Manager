using System.Collections.Generic;
using System.Threading.Tasks;
using Taskmanager.Data.Entities;

namespace Taskmanager.Services.Interfaces
{
    public interface ITodolistService
    {
        public Task<TodoList> GetByIdAsync(int todoListId);
        public Task<List<TodoList>> GetAllAsync(int userId);
        public Task AddAsync(TodoList todolist, int userId);
        public Task DeleteAsync(int userId, int todolistId);
        public Task UpdateAsync(int todoListId, TodoList todoList);
    }
}