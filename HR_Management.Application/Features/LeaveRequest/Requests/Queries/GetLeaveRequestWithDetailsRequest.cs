using HR_Management.Application.DTOs.LeaveRequest;
using MediatR;

namespace HR_Management.Application.Features.LeaveRequest.Requests.Queries
{
    public class GetLeaveRequestWithDetailsRequest : IRequest<LeaveRequestDto>
    {
        public int Id { get; set; }
    }
}
