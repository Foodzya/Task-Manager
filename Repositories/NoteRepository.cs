using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Taskmanager.Data.Context;
using Taskmanager.Data.Entities;
using Taskmanager.Repositories.Interfaces;

namespace Taskmanager.Repositories
{
    public class NoteRepository : INoteRepository
    {
        private readonly TaskManagerContext _context;

        public NoteRepository(TaskManagerContext context)
        {
            _context = context;
        }

        public async Task AddAsync(int todoitemId, Note note)
        {
            note.TodoItemId = todoitemId;

            _context.Notes.Add(note);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int noteId)
        {
            Note deletableNote = await _context.Notes.FirstOrDefaultAsync(note => note.Id == noteId);

            _context.Notes.Remove(deletableNote);

            await _context.SaveChangesAsync();
        }

        public async Task<List<Note>> GetAllAsync()
        {
            return await _context.Notes.ToListAsync();
        }

        public async Task<Note> GetOneAsync(int todoitemId)
        {
            Note requestedNote = await _context.Notes.FirstOrDefaultAsync(note => note.TodoItemId == todoitemId);

            return requestedNote;
        }

        public async Task UpdateAsync(int idOfUpdatableNote, Note updatedNote)
        {
            Note updatableNote = await _context.Notes.FirstOrDefaultAsync(n => n.Id.Equals(idOfUpdatableNote));

            if(updatableNote != null)
            {
                updatableNote.Body = updatedNote.Body;
            }

            await _context.SaveChangesAsync();
        }
    }
}