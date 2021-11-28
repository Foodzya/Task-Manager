using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Taskmanager.Data.Entities;

namespace Taskmanager.Services.Interfaces
{
    public interface ITodoitemService
    {
        public Task AddAsync(Todoitem todoitem);
        public Task DeleteAsync(Todoitem todoitem);
        public Task<List<Todoitem>> GetAllAsync();
        public Task ChangeExecutionStatus(Todoitem todoitem, bool isFinished);
        public Task ChangeDeadlineDate(Todoitem todoitem, DateTime newDeadlinedate);
        public Task ChangePriority(Todoitem todoitem, Priority newPriority);
        public Task<Todoitem> GetOneByIdAsync(int id); 
    }
}