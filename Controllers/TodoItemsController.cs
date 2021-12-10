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
    public class TodoitemsController : ControllerBase
    {
        private readonly ITodoitemService _todoItemService;

        public TodoitemsController(ITodoitemService todoItemService)
        {
            _todoItemService = todoItemService;
        }

        [HttpGet("{todoItemId}")]
        public async Task<ActionResult<TodoItemViewModel>> GetByIdAsync([FromRoute] int todoItemId)
        {
            TodoItem todoItem = await _todoItemService.GetByIdAsync(todoItemId);

            return Ok(TodoItemViewModel.MapTodoItem(todoItem));
        }

        [HttpGet("all/{todoListId}")]
        public async Task<ActionResult<List<TodoItemViewModel>>> GetAllAsync([FromRoute] int todoListId)
        {
            List<TodoItem> todoItems = await _todoItemService.GetAllAsync(todoListId);

            return Ok(todoItems.Select(TodoItemViewModel.MapTodoItem).ToList());
        }
        
        [HttpPost("{todoListId}")]
        public async Task<ActionResult> AddAsync([FromRoute] int todoListId, [FromBody] TodoItemInputModel inputModel)
        {
            TodoItem todoItem = TodoItemInputModel.MapTodoitem(inputModel);

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
        public async Task<ActionResult> UpdateAsync([FromRoute] int todoItemId, [FromBody] TodoItemInputModel inputModel)
        {
            TodoItem todoItem = TodoItemInputModel.MapTodoitem(inputModel);
        
            await _todoItemService.UpdateAsync(todoItemId, todoItem);

            return Ok();
        }
    }
}