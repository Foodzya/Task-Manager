using System.Collections.Generic;
using Taskmanager.Repositories.Interfaces;
using Taskmanager.Data.Entities;
using Taskmanager.Data.Context;
using System.Linq;
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

        public async Task Add(User user)
        {
            await _context.Users.AddAsync(user);
        }

        public async Task Delete(User user)
        {
            _context.Users.Remove(user);
            
            await _context.SaveChangesAsync();
        }

        public async Task<List<User>> GetAll()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetOneById(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

        public Task Update(User user)
        {
            throw new System.NotImplementedException();
        }
    }
}