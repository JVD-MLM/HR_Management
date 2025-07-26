using HR_Management.Application.DTOs.LeaveRequest;
using MediatR;

namespace HR_Management.Application.Features.LeaveRequest.Requests.Queries
{
    public class GetLeaveRequestListWithDetailsRequest : IRequest<List<LeaveRequestDto>>
    {
    }
}
