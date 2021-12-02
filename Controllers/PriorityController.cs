using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Taskmanager.Controllers.ViewModels;
using Taskmanager.Services.Interfaces;
using System.Linq;
using Taskmanager.Data.Entities;
using System;

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
            Priority requiredPriority = await _priorityService.GetByIdAsync(priorityId);

            return Ok(PriorityViewModel.MapPriority(requiredPriority));
        }

        [HttpGet]
        public async Task<ActionResult<List<PriorityViewModel>>> GetAllAsync()
        {
            List<Priority> priorities = await _priorityService.GetAllAsync();

            Func<Priority, PriorityViewModel> priorityMapping = delegate(Priority priority) 
            {
                return PriorityViewModel.MapPriority(priority);
            };

            return Ok(priorities.Select(priorityMapping).ToList());
        }
    }
}