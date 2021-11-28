using System.Collections.Generic;
using System.Threading.Tasks;
using Taskmanager.Data.Entities;

namespace Taskmanager.Repositories.Interfaces
{
    public interface ITodolistRepository
    {
        public Task<Todolist> GetOneByIdAsync(int listId, int userId);
        public Task<List<Todolist>> GetAllAsync();
        public Task AddAsync(Todolist todolist);
        public Task UpdateAsync(int idOfUpdatableTodolist, Todolist updatedTodolist);
        public Task DeleteAsync(Todolist todolist);
    }
}