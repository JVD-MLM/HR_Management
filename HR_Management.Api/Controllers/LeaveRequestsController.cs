using HR_Management.Application.DTOs.LeaveRequest;
using HR_Management.Application.Features.LeaveRequest.Requests.Commands;
using HR_Management.Application.Features.LeaveRequest.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HR_Management.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveRequestsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LeaveRequestsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<LeaveRequestsController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var leaveRequests = await _mediator.Send(new GetLeaveRequestListWithDetailsQuery());
            return Ok(leaveRequests);
        }

        // GET api/<LeaveRequestsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var leaveRequest = await _mediator.Send(new GetLeaveRequestWithDetailsQuery() { Id = id });
            return Ok(leaveRequest);
        }

        // POST api/<LeaveRequestsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] LeaveRequestDto leaveRequestDto)
        {
            var command = new CreateLeaveRequestCommand() { LeaveRequestDto = leaveRequestDto };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // PUT api/<LeaveRequestsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] LeaveRequestDto leaveRequestDto)
        {
            var command = new UpdateLeaveRequestCommand() { Id = id, LeaveRequestDto = leaveRequestDto };
            var response = await _mediator.Send(command);
            return NoContent();
        }

        // DELETE api/<LeaveRequestsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteLeaveRequestCommand() { Id = id };
            var response = await _mediator.Send(command);
            return NoContent();
        }
    }
}
