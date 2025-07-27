using MediatR;

namespace HR_Management.Application.Features.LeaveTypes.Requests.Commands
{
    public class DeleteLeaveTypesCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
