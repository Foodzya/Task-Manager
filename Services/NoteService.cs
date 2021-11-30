using System.Collections.Generic;
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

        public async Task<Note> GetOneById(int noteId)
        {
            return await _noteRepo.GetOneByIdAsync(noteId);
        }

        public async Task<List<Note>> GetAllAsync()
        {
            return await _noteRepo.GetAllAsync();
        }

        public async Task AddAsync()
        {
            await _noteRepo.AddAsync(note);
        }
    }
}