using System.Collections.Generic;
using System.Threading.Tasks;
using Taskmanager.Data.Entities;

namespace Taskmanager.Services.Interfaces
{
    public interface ITodolistService
    {
        public Task<Todolist> GetOneByIdAsync(int listId, int userId);
        public Task<List<Todolist>> GetAllAsync();
        public Task AddAsync(Todolist list);
        public Task DeleteAsync(Todolist list);
        public Task UpdateAsync(int updatableTodolist, Todolist updatedTodolist);
    }
}