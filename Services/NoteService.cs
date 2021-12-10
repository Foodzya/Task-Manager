using System.Threading.Tasks;
using Taskmanager.Data.Entities;
using Taskmanager.Repositories.Interfaces;
using Taskmanager.Services.Interfaces;

namespace Taskmanager.Services
{
    public class NoteService : INoteService
    {
        private readonly INoteRepository _noteRepository;

        public NoteService(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }

        public async Task<Note> GetByIdAsync(int todoItemId)
        {
            return await _noteRepository.GetByIdAsync(todoItemId);
        }

        public async Task UpdateAsync(int noteId, Note note)
        {
            await _noteRepository.UpdateAsync(noteId, note);
        }

        public async Task DeleteAsync(int noteId)
        {
            await _noteRepository.DeleteAsync(noteId);
        }

        public async Task AddAsync(int todoItemId, Note note)
        {
            await _noteRepository.AddAsync(todoItemId, note);
        }
    }
}