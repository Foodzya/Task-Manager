using System.Collections.Generic;
using System.Threading.Tasks;
using Taskmanager.Data.Entities;

namespace Taskmanager.Repositories.Interfaces
{
    public interface IUserRepository
    {
        public Task<User> GetOneById(int id);
        public Task<List<User>> GetAll();
        public Task Add(User user);
        public Task Update(User user);
        public Task Delete(User user);
    }
}