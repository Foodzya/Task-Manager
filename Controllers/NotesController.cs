using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Taskmanager.Controllers.InputModels;
using Taskmanager.Controllers.ViewModels;
using Taskmanager.Data.Entities;
using Taskmanager.Services.Interfaces;

namespace Taskmanager.Controllers
{
    [ApiController]
    [Route("api/notes")]
    public class NotesController : ControllerBase
    {
        private readonly INoteService _noteService;

        public NotesController(INoteService noteService)
        {
            _noteService = noteService;
        }

        [HttpGet("{noteId}")]
        public async Task<ActionResult<NoteViewModel>> GetByIdAsync([FromRoute] int noteId)
        {
            Note note = await _noteService.GetByIdAsync(noteId);

            return Ok(NoteViewModel.MapNote(note));
        }

        [HttpPost("{todoItemId}")]
        public async Task<ActionResult> AddAsync([FromRoute] int todoItemId, [FromBody] NoteInputModel inputModel)
        {
            Note note = NoteInputModel.MapNote(inputModel);

            await _noteService.AddAsync(todoItemId, note);

            return Ok();
        }

        [HttpDelete("{noteId}")]
        public async Task<ActionResult> DeleteAsync([FromRoute] int noteId)
        {
            await _noteService.DeleteAsync(noteId);

            return NoContent();
        }

        [HttpPut("{noteId}")]
        public async Task<ActionResult> UpdateAsync([FromRoute] int noteId, [FromBody] NoteInputModel inputModel)
        {
            await _noteService.UpdateAsync(noteId, NoteInputModel.MapNote(inputModel));

            return NoContent();
        }
    }
}