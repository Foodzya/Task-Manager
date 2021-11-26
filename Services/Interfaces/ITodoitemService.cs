using System.Threading.Tasks;
using Taskmanager.Data.Entities;

namespace Taskmanager.Services.Interfaces
{
    public interface ITodoitemService
    {
        public Task AddAsync(Todoitem item);
        public Task DeleteAsync(Todoitem item);
        public Task GetAllAsync();
        public Task SetExecutionStatus(Todoitem item);
        public Task ChangeDeadlinedate(Todoitem item);
        public Task SetPriority(Todoitem item);
        public Task<Todoitem> GetOneByIdAsync(int id);
        public Task AddNoteAsync(Note note);
        public Task DeleteNoteAsync(Note note);        
    }
}