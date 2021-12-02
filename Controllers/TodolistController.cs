using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Taskmanager.Controllers.ViewModels;
using Taskmanager.Data.Entities;
using Taskmanager.Services.Interfaces;
using System.Linq;
using Taskmanager.Controllers.InputModels;
using System;

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
            Todolist requestedTodolist = await _todolistService.GetByIdAsync(todolistId, userId);

            TodolistViewModel todolistViewModel = TodolistViewModel.MapTodolist(requestedTodolist);

            return Ok(todolistViewModel);
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<List<TodolistViewModel>>> GetAllAsync([FromRoute] int userId)
        {
            List<Todolist> listOfTodolists = await _todolistService.GetAllAsync(userId);

            Func<Todolist, TodolistViewModel> todolistViewModelMapper = delegate (Todolist todolist)
            {
                return TodolistViewModel.MapTodolist(todolist); 
            };

            return Ok(listOfTodolists.Select(todolistViewModelMapper).ToList());
        }

        [HttpPost("{userId}")]
        public async Task<ActionResult> AddAsync([FromRoute] int userId, [FromBody] TodolistInputModel inputModel)
        {
            Todolist newTodolist = TodolistInputModel.MapTodolist(inputModel);

            await _todolistService.AddAsync(newTodolist, userId);

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
            Todolist updatableTodolist = TodolistInputModel.MapTodolist(inputModel);

            await _todolistService.UpdateAsync(userId, todolistId, updatableTodolist);

            return Ok();
        }
    }
}