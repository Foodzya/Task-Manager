using System.Collections.Generic;
using Taskmanager.Data.Entities;

namespace Taskmanager.Repositories.Interfaces
{
    public interface ITodolistRepository
    {
        public Todolist GetOneById(int id);
        public List<Todolist> GetAll();
        public void Add(Todolist todolist);
        public void Update(Todolist todolist);
        public void Delete(Todolist todolist);
    }
}