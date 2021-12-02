using System.Collections.Generic;
using System.Threading.Tasks;
using Taskmanager.Data.Entities;
using Taskmanager.Repositories.Interfaces;
using Taskmanager.Services.Interfaces;

namespace Taskmanager.Services
{
    public class TodoitemService : ITodoitemService
    {
        private readonly ITodoitemRepository _todoitemRepository;

        public TodoitemService(ITodoitemRepository todoitemRepository)
        {
            _todoitemRepository = todoitemRepository;
        }

        public async Task AddAsync(int todolistId, Todoitem todoitem)
        {
            await _todoitemRepository.AddAsync(todolistId, todoitem);
        }

        public async Task DeleteAsync(int todoitemId)
        {
            await _todoitemRepository.DeleteAsync(todoitemId);
        }

        public async Task<List<Todoitem>> GetAllAsync(int userId, int todolistId)
        {
           return await  _todoitemRepository.GetAllAsync(userId, todolistId);
        }

        public async Task<Todoitem> GetByIdAsync(int itemId)
        {
            return await _todoitemRepository.GetByIdAsync(itemId); 
        }

        public async Task UpdateAsync(int todoitemId, Todoitem todoitem)
        {
            await _todoitemRepository.UpdateAsync(todoitemId, todoitem);
        }
    }
}