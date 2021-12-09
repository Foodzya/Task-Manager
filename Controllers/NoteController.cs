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
    public class NoteController : ControllerBase
    {
        private readonly INoteService _noteService;

        public NoteController(INoteService noteService)
        {
            _noteService = noteService;
        }

        [HttpGet("{todoitemId}")]
        public async Task<ActionResult<NoteViewModel>> GetByIdAsync([FromRoute] int todoitemId)
        {
            Note requiredNote = await _noteService.GetByIdAsync(todoitemId);

            return Ok(NoteViewModel.MapNote(requiredNote));
        }

        [HttpPost("{todoitemId}")]
        public async Task<ActionResult> AddAsync ([FromRoute] int todoitemId, [FromBody] NoteInputModel inputModel)
        {
            Note note = NoteInputModel.MapNote(inputModel);

            await _noteService.AddAsync(todoitemId, note);

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