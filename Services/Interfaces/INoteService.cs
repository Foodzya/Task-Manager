using System.Threading.Tasks;
using Taskmanager.Data.Entities;

namespace Taskmanager.Services.Interfaces
{
    public interface INoteService
    {
        public Task<Note> GetOneByIdAsync(int userId, int todolistId, int todoitemId);
        public Task AddAsync(int userId, int todolistId, int todoitemId, Note note);
        public Task UpdateAsync(int idOfUpdatableNote, Note updatedNote);
        public Task DeleteAsync(int noteId);
    }
}