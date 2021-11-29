using Microsoft.AspNetCore.Mvc;
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
        public Task<ActionResult> GetOneByIdAsync([FromRoute] int userId, [FromRoute] int todolistId, [FromRoute] int todoitemId)
        {
            
        }
    }
}