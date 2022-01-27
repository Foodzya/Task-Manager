using System.Collections.Generic;
using System.Threading.Tasks;
using Taskmanager.Data.Entities;
using Taskmanager.Repositories.Interfaces;
using Taskmanager.Services.Interfaces;

namespace Taskmanager.Services
{
    public class TodoitemService : ITodoitemService
    {
        private readonly ITodoitemRepository _todoItemRepository;

        public TodoitemService(ITodoitemRepository todoItemRepository)
        {
            _todoItemRepository = todoItemRepository;
        }

        public async Task AddAsync(int todoListId, TodoItem todoItem)
        {
            await _todoItemRepository.AddAsync(todoListId, todoItem);
        }

        public async Task DeleteAsync(int todoItemId)
        {
            await _todoItemRepository.DeleteAsync(todoItemId);
        }

        public async Task<List<TodoItem>> GetAllAsync(int todoListId)
        {
           return await _todoItemRepository.GetAllAsync(todoListId);
        }

        public async Task<TodoItem> GetByIdAsync(int todoItemId)
        {
            return await _todoItemRepository.GetByIdAsync(todoItemId); 
        }

        public async Task UpdateAsync(int todoItemId, TodoItem todoItem)
        {
            await _todoItemRepository.UpdateAsync(todoItemId, todoItem);
        }
    }
}