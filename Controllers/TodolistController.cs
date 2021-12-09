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

        [HttpGet("{todoListId}")]
        public async Task<ActionResult<TodolistViewModel>> GetOneById([FromRoute] int todoListId)
        {
            TodoList todoList = await _todolistService.GetByIdAsync(todoListId);

            TodolistViewModel todolistViewModel = TodolistViewModel.MapTodolist(todoList);

            return Ok(todolistViewModel);
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<List<TodolistViewModel>>> GetAllAsync([FromRoute] int userId)
        {
            List<TodoList> listOfTodolists = await _todolistService.GetAllAsync(userId);

            Func<TodoList, TodolistViewModel> todolistViewModelMapper = delegate (TodoList todolist)
            {
                return TodolistViewModel.MapTodolist(todolist); 
            };

            return Ok(listOfTodolists.Select(todolistViewModelMapper).ToList());
        }

        [HttpPost("{userId}")]
        public async Task<ActionResult> AddAsync([FromRoute] int userId, [FromBody] TodolistInputModel inputModel)
        {
            TodoList newTodolist = TodolistInputModel.MapTodolist(inputModel);

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
            TodoList updatableTodolist = TodolistInputModel.MapTodolist(inputModel);

            await _todolistService.UpdateAsync(userId, todolistId, updatableTodolist);

            return Ok();
        }
    }
}