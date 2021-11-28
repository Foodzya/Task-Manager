using System.Collections.Generic;
using System.Threading.Tasks;
using Taskmanager.Data.Entities;

namespace Taskmanager.Services.Interfaces
{
    public interface IUserService
    {
        public Task<User> GetOneByIdAsync(int id);
        public Task<List<User>> GetAllAsync();
        public Task AddAsync(User user);
        public Task UpdateAsync(int idOfUpdatableUser, User updatedUser);
    }
}