using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Taskmanager.Controllers.ViewModels;
using Taskmanager.Data.Entities;
using Taskmanager.Services.Interfaces;

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

            return todolistToBeDisplayed;
        } 
    }
}