using System.Collections.Generic;
using Taskmanager.Data.Entities;

namespace Taskmanager.Repositories.Interfaces
{
    public interface IPriorityRepository
    {
        public Priority GetOneById(int id);
        public List<Priority> GetAll();
    }
}