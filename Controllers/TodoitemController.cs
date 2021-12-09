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
        private readonly ITodoitemService _todoItemService;

        public TodoitemController(ITodoitemService todoItemService)
        {
            _todoItemService = todoItemService;
        }

        [HttpGet("{todoItemId}")]
        public async Task<ActionResult<TodoitemViewModel>> GetByIdAsync([FromRoute] int todoItemId)
        {
            TodoItem todoItem = await _todoItemService.GetByIdAsync(todoItemId);

            return Ok(TodoitemViewModel.MapTodoitem(todoItem));
        }

        [HttpGet("{todoListId}")]
        public async Task<ActionResult<List<TodoitemViewModel>>> GetAllAsync([FromRoute] int todoListId)
        {
            List<TodoItem> todoItemsList = await _todoItemService.GetAllAsync(todoListId);

            return Ok(todoItemsList.Select(TodoitemViewModel.MapTodoitem).ToList());
        }
        
        [HttpPost("{todoListId}")]
        public async Task<ActionResult> AddAsync([FromRoute] int todoListId, [FromBody] TodoitemInputModel inputModel)
        {
            TodoItem todoItem = TodoitemInputModel.MapTodoitem(inputModel);

            await _todoItemService.AddAsync(todoListId, todoItem);

            return Ok();
        }

        [HttpDelete("{todoItemId}")]
        public async Task<ActionResult> DeleteAsync([FromRoute] int todoItemId)
        {
            await _todoItemService.DeleteAsync(todoItemId);
            
            return NoContent();
        }

        [HttpPut("{todoItemId}")]
        public async Task<ActionResult> UpdateAsync([FromRoute] int todoItemId, [FromBody] TodoitemInputModel inputModel)
        {
            TodoItem todoItem = TodoitemInputModel.MapTodoitem(inputModel);
        
            await _todoItemService.UpdateAsync(todoItemId, todoItem);

            return Ok();
        }
    }
}