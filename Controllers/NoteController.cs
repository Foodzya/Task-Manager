using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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

        [HttpGet("{noteId")]
        public Task<ActionResult<Note>> GetOneByIdAsync([FromRoute] int noteId)
        {
            Note requiredNote = _noteService. 

            NoteViewModel.MapNote()
        }
    }
}