using System;
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

        [HttpGet("{todoitemId}")]
        public async Task<ActionResult<TodoitemViewModel>> GetByIdAsync([FromRoute] int todoitemId)
        {
            Todoitem requiredTodoitem = await _todoitemService.GetByIdAsync(todoitemId);

            return Ok(TodoitemViewModel.MapTodoitem(requiredTodoitem));
        }

        [HttpGet("{userId}/{todolistId}")]
        public async Task<ActionResult<List<TodoitemViewModel>>> GetAllAsync([FromRoute] int userId, [FromRoute] int todolistId)
        {
            List<Todoitem> todoitemsList = await _todoitemService.GetAllAsync(userId, todolistId);

            Func<Todoitem, TodoitemViewModel> todoitemsMapperToViewModels = delegate(Todoitem todoitem)
            {
                return TodoitemViewModel.MapTodoitem(todoitem);
            };

            return Ok(todoitemsList.Select(todoitemsMapperToViewModels).ToList());
        }
        
        [HttpPost("{todolistId}")]
        public async Task<ActionResult> AddAsync([FromRoute] int todolistId, [FromBody] TodoitemInputModel inputModel)
        {
            Todoitem newTodoitem = TodoitemInputModel.MapTodoitem(inputModel);

            await _todoitemService.AddAsync(todolistId, newTodoitem);

            return Ok();
        }

        [HttpDelete("{todoitemId}")]
        public async Task<ActionResult> DeleteAsync([FromRoute] int todoitemId)
        {
            await _todoitemService.DeleteAsync(todoitemId);
            
            return NoContent();
        }

        [HttpPut("{todoitemId}")]
        public async Task<ActionResult> UpdateAsync([FromRoute] int todoitemId, [FromBody] TodoitemInputModel inputModel)
        {
            Todoitem updatedTodoitem = TodoitemInputModel.MapTodoitem(inputModel);
        
            await _todoitemService.UpdateAsync(todoitemId, updatedTodoitem);

            return Ok();
        }
    }
}