using System.Threading.Tasks;
using Taskmanager.Data.Entities;

namespace Taskmanager.Services.Interfaces
{
    public interface ITodolistService
    {
        public Task AddAsync(Todolist list);
        public Task DeletAsync(Todolist list);
        public Task UpdateTitleAsync();
    }
}