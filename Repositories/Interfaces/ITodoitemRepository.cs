using System.Collections.Generic;
using Taskmanager.Data.Entities;

namespace Taskmanager.Repositories.Interfaces
{
    public interface ITodoitemRepository
    {
        public Todoitem GetOneById(int id);
        public List<Todoitem> GetAll();
        public void Add(Todoitem todoitem);
        public void Update(Todoitem todoitem);
        public void Delete(Todoitem todoitem);
    }
}