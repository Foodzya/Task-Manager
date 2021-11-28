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
            User searchedUser = await _userService.GetOneByIdAsync(userId);

            UserViewModel userToBeDisplayed = UserViewModel.MapUser(searchedUser);

            return Ok(userToBeDisplayed);
        }

        [HttpPost]
        public async Task<ActionResult> AddNewUserAsync([FromBody] UserInputModel userInputModel)
        {
            User newUser = UserInputModel.MapUser(userInputModel);

            await _userService.AddAsync(newUser);
            
            return Ok();
        }

        [HttpPut("{userId}")]
        public async Task<ActionResult> UpdateUser([FromRoute] int userId, [FromBody] UserInputModel inputModel)
        {
            User mappedUser = UserInputModel.MapUser(inputModel);

            await _userService.UpdateAsync(userId, mappedUser);

            return Ok();
        }
    }
}