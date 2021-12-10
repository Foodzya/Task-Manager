using System.Collections.Generic;
using Taskmanager.Repositories.Interfaces;
using Taskmanager.Data.Entities;
using Taskmanager.Data.Context;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;

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

        public async Task DeleteAsync(int userId)
        {
            User user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);

            if (user != null)
            {
                _context.Users.Remove(user);

                await _context.SaveChangesAsync();
            }
            else 
            {
                throw new NullReferenceException("User with the specified ID not found"); 
            }      
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetByIdAsync(int userId)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
        }

        public async Task UpdateAsync(int userId, User newUser)
        {
            User user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);

            if (user != null)
            {
                user.Username = newUser.Username;
                user.Password = newUser.Password;

                await _context.SaveChangesAsync();
            }
            else 
            {
                throw new NullReferenceException("User with the specified ID not found");
            }
        }
    }
}