using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Taskmanager.Controllers.InputModels;
using Taskmanager.Controllers.ViewModels;
using Taskmanager.Data.Entities;
using Taskmanager.Services.Interfaces;

namespace Taskmanager.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<UserViewModel>> GetOneByIdAsync([FromRoute] int userId)
        {
            User user = await _userService.GetByIdAsync(userId);

            UserViewModel userViewModel = UserViewModel.MapUser(user);

            return Ok(userViewModel);
        }

        [HttpPost]
        public async Task<ActionResult> AddAsync([FromBody] UserInputModel userInputModel)
        {
            User user = UserInputModel.MapUser(userInputModel);

            await _userService.AddAsync(user);
            
            return Ok();
        }

        [HttpPut("{userId}")]
        public async Task<ActionResult> UpdateAsync([FromRoute] int userId, [FromBody] UserInputModel inputModel)
        {
            User user = UserInputModel.MapUser(inputModel);

            await _userService.UpdateAsync(userId, user);

            return Ok();
        }
    }
}