using System.Collections.Generic;
using System.Threading.Tasks;
using Taskmanager.Data.Entities;

namespace Taskmanager.Services.Interfaces
{
    public interface IUserService
    {
        public Task<User> GetByIdAsync(int userId);
        public Task<List<User>> GetAllAsync();
        public Task AddAsync(User user);
        public Task UpdateAsync(int userId, User user);
    }
}