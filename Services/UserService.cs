using System.Collections.Generic;
using System.Threading.Tasks;
using Taskmanager.Data.Entities;
using Taskmanager.Repositories.Interfaces;
using Taskmanager.Services.Interfaces;

namespace Taskmanager.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepo;

        public UserService(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        public async Task AddAsync(User user)
        {
            await _userRepo.AddAsync(user);
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _userRepo.GetAllAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _userRepo.GetByIdAsync(id);
        }

        public async Task UpdateAsync(int idOfUpdatableUser, User updatedUser)
        {
            await _userRepo.UpdateAsync(idOfUpdatableUser, updatedUser);
        }
    }
}