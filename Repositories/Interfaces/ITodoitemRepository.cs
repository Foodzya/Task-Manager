using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Taskmanager.Data.Entities;

namespace Taskmanager.Repositories.Interfaces
{
    public interface ITodoitemRepository
    {
        public Task<Todoitem> GetOneByIdAsync(int id);
        public Task<List<Todoitem>> GetAllAsync();
        public Task AddAsync(Todoitem todoitem);
        public Task UpdateAsync(Todoitem updatedTodoitem);
        public Task DeleteAsync(Todoitem todoitem);
    }
}