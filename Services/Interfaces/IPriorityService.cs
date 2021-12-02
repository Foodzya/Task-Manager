using System.Collections.Generic;
using System.Threading.Tasks;
using Taskmanager.Data.Entities;

namespace Taskmanager.Services.Interfaces
{
    public interface IPriorityService
    {
        public Task<Priority> GetByIdAsync(int id);
        public Task<List<Priority>> GetAllAsync();
    }
}