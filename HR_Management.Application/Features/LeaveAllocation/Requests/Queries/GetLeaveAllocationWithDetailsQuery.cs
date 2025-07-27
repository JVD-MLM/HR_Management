using HR_Management.Application.DTOs.LeaveAllocation;
using MediatR;

namespace HR_Management.Application.Features.LeaveAllocation.Requests.Queries
{
    public class GetLeaveAllocationWithDetailsQuery : IRequest<LeaveAllocationDto>
    {
        public int Id { get; set; }
    }
}
