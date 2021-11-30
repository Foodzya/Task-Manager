using System.Collections.Generic;
using System.Threading.Tasks;
using Taskmanager.Data.Entities;

namespace Taskmanager.Repositories.Interfaces
{
    public interface ITodoitemRepository
    {
        public Task<Todoitem> GetOneByIdAsync(int userId, int listId, int itemId);
        public Task<List<Todoitem>> GetAllAsync(int userId, int listId);
        public Task AddAsync(Todoitem todoitem);
        public Task UpdateAsync(int userId, int listId, int itemId, Todoitem item);
        public Task DeleteAsync(int userId, int listId, int itemId);
    }
}