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

        public async Task AddAsync(int itemId, Note note)
        {
            await _context.Notes.AddAsync(note);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Note note)
        {
            _context.Notes.Remove(note);

            await _context.SaveChangesAsync();
        }

        public async Task<List<Note>> GetAllAsync()
        {
            return await _context.Notes.ToListAsync();
        }

        public async Task<Note> GetOneByIdAsync(int id)
        {
            return await _context.Notes.FirstAsync(n => n.Id == id); 
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