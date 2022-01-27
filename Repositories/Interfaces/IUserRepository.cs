using System.Collections.Generic;
using System.Threading.Tasks;
using Taskmanager.Data.Entities;

namespace Taskmanager.Repositories.Interfaces
{
    public interface IUserRepository
    {
        public Task<User> GetByIdAsync(int userId);
        public Task<List<User>> GetAllAsync();
        public Task AddAsync(User user);
        public Task DeleteAsync(int userId);
        public Task UpdateAsync(int userId, User user);
    }
}