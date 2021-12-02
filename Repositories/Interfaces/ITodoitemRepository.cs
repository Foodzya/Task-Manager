using System.Collections.Generic;
using System.Threading.Tasks;
using Taskmanager.Data.Entities;

namespace Taskmanager.Repositories.Interfaces
{
    public interface ITodoitemRepository
    {
        public Task<Todoitem> GetByIdAsync(int todoitemId);
        public Task<List<Todoitem>> GetAllAsync(int userId, int todolistId);
        public Task AddAsync(int todolistId, Todoitem todoitem);
        public Task UpdateAsync(int todoitemId, Todoitem todoitem);
        public Task DeleteAsync(int todoitemId);
    }
}