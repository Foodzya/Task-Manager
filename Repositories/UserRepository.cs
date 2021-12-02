using System.Collections.Generic;
using Taskmanager.Repositories.Interfaces;
using Taskmanager.Data.Entities;
using Taskmanager.Data.Context;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Taskmanager.Repositories
{
    public class UserRepository : IUserRepository
    {
        private TaskManagerContext _context;

        public UserRepository(TaskManagerContext context)
        {
            _context = context;
        }

        public async Task AddAsync(User user)
        {
            _context.Users.Add(user);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(User user)
        {
            _context.Users.Remove(user);
            
            await _context.SaveChangesAsync();
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task UpdateAsync(int idOfUpdatableUser, User updatedUser)
        {
            User updatableUser = await _context.Users.FirstOrDefaultAsync(u => u.Id == idOfUpdatableUser);

            if(updatableUser != null)
            {
                updatableUser.Username = updatedUser.Username;
                updatableUser.Password = updatedUser.Password;
            }

            await _context.SaveChangesAsync();
        }
    }
}