using System.Threading.Tasks;
using Taskmanager.Data.Entities;

namespace Taskmanager.Repositories.Interfaces
{
    public interface INoteRepository
    {
        public Task<Note> GetByIdAsync(int noteId);
        public Task AddAsync(int todoItemId, Note note);
        public Task UpdateAsync(int noteId, Note note);
        public Task DeleteAsync(int noteId);
    }
}