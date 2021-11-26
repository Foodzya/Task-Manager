using System.Threading.Tasks;
using Taskmanager.Data.Entities;
using Taskmanager.Services.Interfaces;

namespace Taskmanager.Services
{
    public class TodoitemService : ITodoitemService
    {
        public Task AddAsync(Todoitem item)
        {
            return null;
        }

        public Task AddNoteAsync(Note note)
        {
            throw new System.NotImplementedException();
        }

        public Task ChangeDeadlinedate(Todoitem item)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteAsync(Todoitem item)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteNoteAsync(Note note)
        {
            throw new System.NotImplementedException();
        }

        public Task GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<Todoitem> GetOneByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task SetExecutionStatus(Todoitem item)
        {
            throw new System.NotImplementedException();
        }

        public Task SetPriority(Todoitem item)
        {
            throw new System.NotImplementedException();
        }
    }
}