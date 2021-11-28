using System.Collections.Generic;
using System.Threading.Tasks;
using Taskmanager.Data.Entities;
using Taskmanager.Repositories.Interfaces;
using Taskmanager.Services.Interfaces;

namespace Taskmanager.Services
{
    public class PriorityService : IPriorityService
    {
        private readonly IPriorityRepository _priorityRepo;

        public PriorityService(IPriorityRepository priorityRepo)
        {
            _priorityRepo = priorityRepo;
        }

        public async Task<List<Priority>> GetAllAsync()
        {
            return await _priorityRepo.GetAllAsync();
        }

        public async Task<Priority> GetOneByIdAsync(int id)
        {
            return await _priorityRepo.GetOneByIdAsync(id);
        }
    }
}