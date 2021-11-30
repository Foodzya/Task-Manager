using System.Threading.Tasks;
using Taskmanager.Data.Entities;
using Taskmanager.Repositories.Interfaces;
using Taskmanager.Services.Interfaces;

namespace Taskmanager.Services
{
    public class NoteService : INoteService
    {
        private readonly INoteRepository _noteRepo;

        public NoteService(INoteRepository noteRepo)
        {
            _noteRepo = noteRepo;
        }

        public async Task<Note> GetOneByIdAsync(int userId, int todolistId, int todoitemId)
        {
            return await _noteRepo.GetOneAsync(userId, todolistId, todoitemId);
        }

        public async Task UpdateAsync(int idOfUpdatableNote, Note updatedNote)
        {
            await _noteRepo.UpdateAsync(idOfUpdatableNote, updatedNote);
        }

        public async Task DeleteAsync(int noteId)
        {
            await _noteRepo.DeleteAsync(noteId);
        }

        public async Task AddAsync(int userId, int todolistId, int todoitemId, Note note)
        {
            await _noteRepo.AddAsync(userId, todolistId, todoitemId, note);
        }
    }
}