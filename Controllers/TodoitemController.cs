using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Taskmanager.Controllers.InputModels;
using Taskmanager.Controllers.ViewModels;
using Taskmanager.Data.Entities;
using Taskmanager.Services.Interfaces;

namespace Taskmanager.Controllers
{
    [ApiController]
    [Route("api/todoitems")]
    public class TodoitemController : ControllerBase
    {
        private readonly ITodoitemService _todoitemService;

        public TodoitemController(ITodoitemService todoitemService)
        {
            _todoitemService = todoitemService;
        }

        [HttpGet("{userId}/{todolistId}/{todoitemId}")]
        public async Task<ActionResult<TodoitemViewModel>> GetOneByIdAsync([FromRoute] int userId, [FromRoute] int todolistId, [FromRoute] int todoitemId)
        {
            Todoitem requiredTodoitem = await _todoitemService.GetOneByIdAsync(userId, todolistId, todoitemId);

            return Ok(TodoitemViewModel.MapTodoitem(requiredTodoitem));
        }

        [HttpGet("{userId}/{listId}")]
        public async Task<ActionResult<List<TodoitemViewModel>>> GetAllAsync([FromRoute] int userId, [FromRoute] int listId)
        {
            List<Todoitem> todoitemsList = await _todoitemService.GetAllAsync(userId, listId);

            return todoitemsList.Select(item => TodoitemViewModel.MapTodoitem(item)).ToList();
        }
        
        [HttpPost("{listId}")]
        public async Task<ActionResult> AddAsync([FromRoute] int listId, [FromBody] TodoitemInputModel inputModel)
        {
            Todoitem newTodoitem = TodoitemInputModel.MapTodoitem(inputModel);
            newTodoitem.Todolistid = listId;

            await _todoitemService.AddAsync(newTodoitem);

            return Ok();
        }

        [HttpDelete("{userId}/{listId}/{itemId}")]
        public async Task<ActionResult> DeleteAsync([FromRoute] int userId, [FromRoute] int listId, [FromRoute] int itemId)
        {
            await _todoitemService.DeleteAsync(userId, listId, itemId);
            
            return NoContent();
        }

        [HttpPut("{userId}/{listId}/{itemId}")]
        public async Task<ActionResult> UpdateAsync([FromRoute] int userId, [FromRoute] int listId, [FromRoute] int itemId, [FromBody] TodoitemInputModel inputModel)
        {
            Todoitem tempTodoitem = TodoitemInputModel.MapTodoitem(inputModel);
        
            await _todoitemService.UpdateAsync(userId, listId, itemId, tempTodoitem);

            return Ok();
        }
    }
}