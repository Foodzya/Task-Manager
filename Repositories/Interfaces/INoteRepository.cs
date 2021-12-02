using System.Threading.Tasks;
using Taskmanager.Data.Entities;

namespace Taskmanager.Repositories.Interfaces
{
    public interface INoteRepository
    {
        public Task<Note> GetOneAsync(int todoitemId);
        public Task AddAsync(int todoitemId, Note note);
        public Task UpdateAsync(int idOfUpdatableNote, Note updatedNote);
        public Task DeleteAsync(int noteId);
    }
}