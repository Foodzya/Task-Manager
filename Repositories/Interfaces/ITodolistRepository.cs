using System.Collections.Generic;
using System.Threading.Tasks;
using Taskmanager.Data.Entities;

namespace Taskmanager.Repositories.Interfaces
{
    public interface ITodolistRepository
    {
        public Task<Todolist> GetOneById(int id);
        public Task<List<Todolist>> GetAll();
        public Task Add(Todolist todolist);
        public Task Update(Todolist todolist);
        public Task Delete(Todolist todolist);
    }
}