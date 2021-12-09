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

        public async Task<Note> GetByIdAsync(int todoitemId)
        {
            return await _noteRepository.GetOneAsync(todoitemId);
        }

        public async Task UpdateAsync(int idOfUpdatableNote, Note updatedNote)
        {
            await _noteRepository.UpdateAsync(idOfUpdatableNote, updatedNote);
        }

        public async Task DeleteAsync(int noteId)
        {
            await _noteRepository.DeleteAsync(noteId);
        }

        public async Task AddAsync(int todoitemId, Note note)
        {
            await _noteRepository.AddAsync(todoitemId, note);
        }
    }
}