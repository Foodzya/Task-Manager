using System.Collections.Generic;
using System.Threading.Tasks;
using Taskmanager.Data.Entities;
using Taskmanager.Repositories.Interfaces;
using Taskmanager.Services.Interfaces;

namespace Taskmanager.Services
{
    public class PriorityService : IPriorityService
    {
        private readonly IPriorityRepository _priorityRepository;

        public PriorityService(IPriorityRepository priorityRepository)
        {
            _priorityRepository = priorityRepository;
        }

        public async Task<List<Priority>> GetAllAsync()
        {
            return await _priorityRepository.GetAllAsync();
        }

        public async Task<Priority> GetByIdAsync(int priorityId)
        {
            return await _priorityRepository.GetByIdAsync(priorityId);
        }
    }
}