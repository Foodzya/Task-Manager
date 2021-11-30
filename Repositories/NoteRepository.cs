using System.Collections.Generic;
using System.Linq;
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

        public async Task AddAsync(int userId, int todolistId, int todoitemId, Note note)
        {
            Todolist todolist = await _context.Todolists.FirstOrDefaultAsync(list => list.Userid == userId && list.Id == todolistId);

            await _context.Notes.AddAsync(note);
        
            todolist.Todoitems.FirstOrDefault(item => item.Id == todoitemId).Noteid = note.Id;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int noteId)
        {
            _context.Notes.Remove(await _context.Notes.FirstOrDefaultAsync(note => note.Id == noteId));

            await _context.SaveChangesAsync();
        }

        public async Task<List<Note>> GetAllAsync()
        {
            return await _context.Notes.ToListAsync();
        }

        public async Task<Note> GetOneAsync(int userId, int todolistId, int todoitemId)
        {
            Todolist listWithRequiredTodoitem = await _context.Todolists.FirstOrDefaultAsync(list => list.Id == todolistId && list.Userid == userId);

            return listWithRequiredTodoitem.Todoitems.FirstOrDefault(item => item.Id == todoitemId).Note;
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