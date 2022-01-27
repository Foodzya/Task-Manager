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
    public class PrioritiesController : ControllerBase
    {
        private readonly IPriorityService _priorityService;

        public PrioritiesController(IPriorityService priorityService)
        {
            _priorityService = priorityService;
        }

        [HttpGet("{priorityId}")]
        public async Task<ActionResult<PriorityViewModel>> GetByIdAsync([FromRoute] int priorityId)
        {
            Priority priority = await _priorityService.GetByIdAsync(priorityId);

            return Ok(PriorityViewModel.MapPriority(priority));
        }

        [HttpGet]
        public async Task<ActionResult<List<PriorityViewModel>>> GetAllAsync()
        {
            List<Priority> priorities = await _priorityService.GetAllAsync();

            return Ok(priorities.Select(PriorityViewModel.MapPriority).ToList());
        }
    }
}