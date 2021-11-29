using System.Collections.Generic;
using System.Threading.Tasks;
using Taskmanager.Data.Entities;

namespace Taskmanager.Services.Interfaces
{
    public interface ITodolistService
    {
        public Task<Todolist> GetOneByIdAsync(int listId, int userId);
        public Task<List<Todolist>> GetAllAsync(int userId);
        public Task AddAsync(Todolist list);
        public Task DeleteAsync(int userId, int todolistId);
        public Task UpdateAsync(int userId, int updatableTodolist, Todolist updatedTodolist);
    }
}