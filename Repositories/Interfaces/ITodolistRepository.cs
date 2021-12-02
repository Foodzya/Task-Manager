using System.Collections.Generic;
using System.Threading.Tasks;
using Taskmanager.Data.Entities;

namespace Taskmanager.Repositories.Interfaces
{
    public interface ITodolistRepository
    {
        public Task<Todolist> GetByIdAsync(int todolistId, int userId);
        public Task<List<Todolist>> GetAllAsync(int userId);
        public Task AddAsync(Todolist todolist);
        public Task UpdateAsync(int userId, int idOfUpdatableTodolist, Todolist updatedTodolist);
        public Task DeleteAsync(int userId, int todolistId);
    }
}