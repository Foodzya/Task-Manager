using System.Collections.Generic;
using System.Threading.Tasks;
using Taskmanager.Data.Entities;

namespace Taskmanager.Repositories.Interfaces
{
    public interface ITodoitemRepository
    {
        public Task<Todoitem> GetOneById(int id);
        public Task<List<Todoitem>> GetAll();
        public Task Add(Todoitem todoitem);
        public Task Update(Todoitem todoitem);
        public Task Delete(Todoitem todoitem);
    }
}