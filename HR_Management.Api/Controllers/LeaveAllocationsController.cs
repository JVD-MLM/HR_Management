using HR_Management.Application.DTOs.LeaveAllocation;
using HR_Management.Application.Features.LeaveAllocation.Requests.Commands;
using HR_Management.Application.Features.LeaveAllocation.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HR_Management.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveAllocationsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LeaveAllocationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<LeaveAllocationsController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var leaveAllocations = await _mediator.Send(new GetLeaveAllocationListWithDetailsQuery());
            return Ok(leaveAllocations);
        }

        // GET api/<LeaveAllocationsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var leaveAllocation = await _mediator.Send(new GetLeaveAllocationWithDetailsQuery() { Id = id });
            return Ok(leaveAllocation);
        }

        // POST api/<LeaveAllocationsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] LeaveAllocationDto leaveAllocationDto)
        {
            var command = new CreateLeaveAllocationCommand() { LeaveAllocationDto = leaveAllocationDto };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // PUT api/<LeaveAllocationsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] LeaveAllocationDto leaveAllocationDto)
        {
            var command = new UpdateLeaveAllocationCommand() { LeaveAllocationDto = leaveAllocationDto };
            var response = await _mediator.Send(command);
            return NoContent();
        }

        // DELETE api/<LeaveAllocationsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteLeaveAllocationCommand() { Id = id };
            var response = await _mediator.Send(command);
            return NoContent();
        }
    }
}
