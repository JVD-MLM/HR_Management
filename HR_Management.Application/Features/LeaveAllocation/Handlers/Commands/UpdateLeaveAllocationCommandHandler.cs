using AutoMapper;
using HR_Management.Application.Features.LeaveAllocation.Requests.Commands;
using HR_Management.Application.Contracts.Persistence;
using MediatR;

namespace HR_Management.Application.Features.LeaveAllocation.Handlers.Commands
{
    public class UpdateLeaveAllocationCommandHandler:IRequestHandler<UpdateLeaveAllocationCommand,Unit>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly IMapper _mapper;

        public UpdateLeaveAllocationCommandHandler(ILeaveAllocationRepository leaveAllocationRepository, IMapper mapper)
        {
            _leaveAllocationRepository = leaveAllocationRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateLeaveAllocationCommand request, CancellationToken cancellationToken)
        {
            var leaveAllocation = await _leaveAllocationRepository.Get(request.LeaveAllocationDto.Id);
            leaveAllocation = _mapper.Map(request.LeaveAllocationDto,leaveAllocation);
            await _leaveAllocationRepository.Update(leaveAllocation);
            return Unit.Value;
        }
    }
}
