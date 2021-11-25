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

        [HttpGet("{id}")]
        public ActionResult<User> GetById([FromRoute] int id)
        {
            return _userRepo.GetOneById(1);
        }
    }
}