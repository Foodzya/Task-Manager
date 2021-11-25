using System.Collections.Generic;
using Taskmanager.Data.Entities;

namespace Taskmanager.Repositories.Interfaces
{
    public interface IUserRepository
    {
        public User GetOneById(int id);
        public List<User> GetAll();
        public void Add(User user);
        public void Update(User user);
        public void Delete(User user);
    }
}