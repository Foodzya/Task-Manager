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
    public class TodolistsController : ControllerBase
    {
        private readonly ITodolistService _todoListService;

        public TodolistsController(ITodolistService todoListService)
        {
            _todoListService = todoListService;
        }

        [HttpGet("{todoListId}")]
        public async Task<ActionResult<TodoListViewModel>> GetByIdAsync([FromRoute] int todoListId)
        {
            TodoList todoList = await _todoListService.GetByIdAsync(todoListId);

            TodoListViewModel todoListViewModel = TodoListViewModel.MapTodoList(todoList);

            return Ok(todoListViewModel);
        }

        [HttpGet("all/{userId}")]
        public async Task<ActionResult<List<TodoListViewModel>>> GetAllAsync([FromRoute] int userId)
        {
            List<TodoList> todoLists = await _todoListService.GetAllAsync(userId);

            return Ok(todoLists.Select(TodoListViewModel.MapTodoList).ToList());
        }

        [HttpPost("{userId}")]
        public async Task<ActionResult> AddAsync([FromRoute] int userId, [FromBody] TodoListInputModel inputModel)
        {
            TodoList todoList = TodoListInputModel.MapTodolist(inputModel);

            await _todoListService.AddAsync(todoList, userId);

            return NoContent();
        }

        [HttpDelete("{todoListId}")]
        public async Task<ActionResult> DeleteAsync([FromRoute] int todoListId)
        {
            await _todoListService.DeleteAsync(todoListId);

            return NoContent();
        }

        [HttpPut("{todoListId}")]
        public async Task<ActionResult> UpdateAsync([FromRoute] int todoListId, [FromBody] TodoListInputModel inputModel)
        {
            TodoList todoList = TodoListInputModel.MapTodolist(inputModel);

            await _todoListService.UpdateAsync(todoListId, todoList);

            return Ok();
        }
    }
}