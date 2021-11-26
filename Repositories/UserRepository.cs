using System.Collections.Generic;
using Taskmanager.Repositories.Interfaces;
using Taskmanager.Data.Entities;
using Taskmanager.Data.Context;
using System.Linq;
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
            await _context.Users.AddAsync(user);

            await _context.SaveChangesAsync();
        }

        public async Task AddNewTodolist(int listId)
        {
            
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

        public async Task<User> GetOneByIdAsync(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

        public Task UpdateAsync(User user)
        {
            throw new System.NotImplementedException();
        }
    }
}