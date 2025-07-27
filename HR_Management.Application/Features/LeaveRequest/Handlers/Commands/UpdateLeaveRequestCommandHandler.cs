using AutoMapper;
using HR_Management.Application.Features.LeaveRequest.Requests.Commands;
using HR_Management.Application.Contracts.Persistence;
using MediatR;

namespace HR_Management.Application.Features.LeaveRequest.Handlers.Commands
{
    public class UpdateLeaveRequestCommandHandler : IRequestHandler<UpdateLeaveRequestCommand, Unit>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _mapper;

        public UpdateLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            var leaveRequest = await _leaveRequestRepository.Get(request.Id);
            if (request.LeaveRequestDto != null)
            {
                leaveRequest = _mapper.Map(request.LeaveRequestDto, leaveRequest);
                await _leaveRequestRepository.Update(leaveRequest);
            }
            else if (request.ApproveLeaveRequestDto != null)
            {
                leaveRequest = _mapper.Map(request.ApproveLeaveRequestDto, leaveRequest);
                await _leaveRequestRepository.Update(leaveRequest);
            }

            return Unit.Value;
        }
    }
}
