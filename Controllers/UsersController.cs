using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Taskmanager.Data.Entities;
using Taskmanager.Repositories;
using Taskmanager.Repositories.Interfaces;

namespace Taskmanager.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepo;

        public UsersController(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        [HttpPost("{listId}")]
        public async Task<ActionResult> AddNewTodolistToUser([FromRoute] int listId)
        {
            await _userRepo.AddNewTodolist(1);

            return Ok();
        }
    }
}