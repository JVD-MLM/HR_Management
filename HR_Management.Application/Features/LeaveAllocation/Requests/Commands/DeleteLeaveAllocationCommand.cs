using MediatR;

namespace HR_Management.Application.Features.LeaveAllocation.Requests.Commands
{
    public class DeleteLeaveAllocationCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
