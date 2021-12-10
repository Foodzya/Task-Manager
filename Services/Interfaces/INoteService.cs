using System.Threading.Tasks;
using Taskmanager.Data.Entities;

namespace Taskmanager.Services.Interfaces
{
    public interface INoteService
    {
        public Task<Note> GetByIdAsync(int todoItemId);
        public Task AddAsync(int todoItemId, Note note);
        public Task UpdateAsync(int noteId, Note note);
        public Task DeleteAsync(int noteId);
    }
}