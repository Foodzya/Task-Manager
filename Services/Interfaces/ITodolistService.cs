using System.Collections.Generic;
using System.Threading.Tasks;
using Taskmanager.Data.Entities;

namespace Taskmanager.Services.Interfaces
{
    public interface ITodolistService
    {
        public Task<Todolist> GetByIdAsync(int todolistId, int userId);
        public Task<List<Todolist>> GetAllAsync(int userId);
        public Task AddAsync(Todolist todolist, int userId);
        public Task DeleteAsync(int userId, int todolistId);
        public Task UpdateAsync(int userId, int updatableTodolist, Todolist updatedTodolist);
    }
}