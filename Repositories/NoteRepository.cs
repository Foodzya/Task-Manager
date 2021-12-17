using System;
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

        public async Task AddAsync(int todoItemId, Note note)
        {
            note.TodoItemId = todoItemId;

            _context.Notes.Add(note);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int noteId)
        {
            Note note = await _context.Notes.FirstOrDefaultAsync(note => note.Id == noteId);

            if (note != null)
            {
                _context.Notes.Remove(note);

                await _context.SaveChangesAsync();
            }
            else 
            {
                throw new NullReferenceException("Note with the specified ID not found");
            }
        }

        public async Task<List<Note>> GetAllAsync()
        {
            return await _context.Notes.ToListAsync();
        }

        public async Task<Note> GetByIdAsync(int noteId)
        {
            Note note = await _context.Notes.FirstOrDefaultAsync(note => note.Id == noteId);

            return note;
        }

        public async Task UpdateAsync(int noteId, Note newNote)
        {
            Note note = await _context.Notes.FirstOrDefaultAsync(n => n.Id.Equals(noteId));

            if (note != null)
            {
                note.Body = newNote.Body;

                await _context.SaveChangesAsync();
            }
            else 
            {
                throw new NullReferenceException("Note with the specified ID not found");
            }
        }
    }
}