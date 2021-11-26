using System.Collections.Generic;
using System.Threading.Tasks;
using Taskmanager.Data.Entities;

namespace Taskmanager.Repositories.Interfaces
{
    public interface IPriorityRepository
    {
        public Task<Priority> GetOneById(int id);
        public Task<List<Priority>> GetAll();
    }
}