using System.Collections.Generic;
using System.Threading.Tasks;
using Taskmanager.Data.Entities;

namespace Taskmanager.Repositories.Interfaces
{
    public interface INoteRepository
    {
        public Task<Note> GetOneById(int id);
        public Task<List<Note>> GetAll();
        public Task Add(Note note);
        public Task Update(Note note);
        public Task Delete(Note note);
    }
}