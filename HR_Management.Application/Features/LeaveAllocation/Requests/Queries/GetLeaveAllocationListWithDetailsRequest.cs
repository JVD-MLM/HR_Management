using HR_Management.Application.DTOs.LeaveAllocation;
using MediatR;

namespace HR_Management.Application.Features.LeaveAllocation.Requests.Queries
{
    public class GetLeaveAllocationListWithDetailsRequest : IRequest<List<LeaveAllocationDto>>
    {
    }
}
