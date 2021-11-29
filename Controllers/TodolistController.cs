using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Taskmanager.Controllers.ViewModels;
using Taskmanager.Data.Entities;
using Taskmanager.Services.Interfaces;
using System.Linq;
using Taskmanager.Controllers.InputModels;

namespace Taskmanager.Controllers
{
    [ApiController]
    [Route("api/todolists")]
    public class TodolistController : ControllerBase
    {
        private readonly ITodolistService _todolistService;

        public TodolistController(ITodolistService todolistService)
        {
            _todolistService = todolistService;
        }

        [HttpGet("{userId}/{todolistId}")]
        public async Task<ActionResult<TodolistViewModel>> GetOneById([FromRoute] int todolistId, [FromRoute] int userId)
        {
            Todolist todolist = await _todolistService.GetOneByIdAsync(todolistId, userId);

            TodolistViewModel todolistToBeDisplayed = TodolistViewModel.MapTodolist(todolist);

            return Ok(todolistToBeDisplayed);
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<List<TodolistViewModel>>> GetAllAsync([FromRoute] int userId)
        {
            List<Todolist> listOfTodolists = await _todolistService.GetAllAsync(userId);

            return Ok(listOfTodolists.Select(list => TodolistViewModel.MapTodolist(list)).ToList());
        }

        [HttpPost("{userId}")]
        public async Task<ActionResult> AddAsync([FromRoute] int userId, [FromBody] TodolistInputModel inputModel)
        {
            await _todolistService.AddAsync(TodolistInputModel.MapTodolist(userId, inputModel));

            return NoContent();
        }

        [HttpDelete("{userId}/{todolistId}")]
        public async Task<ActionResult> DeleteAsync([FromRoute] int userId, [FromRoute] int todolistId)
        {
            await _todolistService.DeleteAsync(userId, todolistId);

            return NoContent();
        }

        [HttpPut("{userId}/{todolistId}")]
        public async Task<ActionResult> UpdateAsync([FromRoute] int userId, [FromRoute] int todolistId, [FromBody] TodolistInputModel inputModel)
        {
            Todolist updatableTodolist = TodolistInputModel.MapTodolist(userId, inputModel);

            await _todolistService.UpdateAsync(userId, todolistId, updatableTodolist);

            return Ok();
        }
    }
}