using System.Collections.Generic;
using System.Threading.Tasks;
using Taskmanager.Data.Entities;

namespace Taskmanager.Services.Interfaces
{
    public interface INoteService
    {
        public Task<Note> GetOneByIdAsync(int id);
        public Task<List<Note>> GetAllAsync();
        public Task AddAsync(Note note);
        public Task UpdateAsync(int idOfUpdatableNote, Note updatedNote);
        public Task DeleteAsync(Note note);
    }
}