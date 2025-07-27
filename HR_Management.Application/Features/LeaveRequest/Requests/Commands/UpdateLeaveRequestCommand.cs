using HR_Management.Application.DTOs.LeaveRequest;
using MediatR;

namespace HR_Management.Application.Features.LeaveRequest.Requests.Commands
{
    public class UpdateLeaveRequestCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public LeaveRequestDto? LeaveRequestDto { get; set; }
        public ApproveLeaveRequestDto? ApproveLeaveRequestDto { get; set; }
    }
}
