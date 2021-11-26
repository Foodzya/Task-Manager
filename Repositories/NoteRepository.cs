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

        public async Task Add(Note note)
        {
            await _context.Notes.AddAsync(note);

            await _context.SaveChangesAsync();
        }

        public async Task Delete(Note note)
        {
            _context.Notes.Remove(note);

            await _context.SaveChangesAsync();
        }

        public async Task<List<Note>> GetAll()
        {
            return await _context.Notes.ToListAsync();
        }

        public async Task<Note> GetOneById(int id)
        {
            return await _context.Notes.FirstAsync(n => n.Id == id); 
        }

        public Task Update(Note note)
        {
            throw new System.NotImplementedException();
        }
    }
}