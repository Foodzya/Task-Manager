using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Taskmanager.Controllers.ViewModels;
using Taskmanager.Services.Interfaces;
using System.Linq;
using Taskmanager.Data.Entities;

namespace Taskmanager.Controllers
{
    [ApiController]
    [Route("api/priorities")]
    public class PriorityController : ControllerBase
    {
        private readonly IPriorityService _priorityService;

        public PriorityController(IPriorityService priorityService)
        {
            _priorityService = priorityService;
        }

        [HttpGet("{priorityId}")]
        public async Task<ActionResult<PriorityViewModel>> GetOneByIdAsync([FromRoute] int priorityId)
        {
            return Ok(PriorityViewModel.MapPriority(await _priorityService.GetOneByIdAsync(priorityId)));
        }

        [HttpGet]
        public async Task<ActionResult<List<PriorityViewModel>>> GetAllAsync()
        {
            List<Priority> priorities = await _priorityService.GetAllAsync();

            return priorities.Select(priority => PriorityViewModel.MapPriority(priority)).ToList();
        }
    }
}