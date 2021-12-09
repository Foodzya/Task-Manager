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

        public async Task AddAsync(int todolistId, TodoItem todoitem)
        {
            await _todoitemRepository.AddAsync(todolistId, todoitem);
        }

        public async Task DeleteAsync(int todoitemId)
        {
            await _todoitemRepository.DeleteAsync(todoitemId);
        }

        public async Task<List<TodoItem>> GetAllAsync(int todoListId)
        {
           return await  _todoitemRepository.GetAllAsync(todoListId);
        }

        public async Task<TodoItem> GetByIdAsync(int itemId)
        {
            return await _todoitemRepository.GetByIdAsync(itemId); 
        }

        public async Task UpdateAsync(int todoitemId, TodoItem todoitem)
        {
            await _todoitemRepository.UpdateAsync(todoitemId, todoitem);
        }
    }
}