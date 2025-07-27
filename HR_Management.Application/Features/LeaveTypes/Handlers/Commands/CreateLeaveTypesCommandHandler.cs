using AutoMapper;
using HR_Management.Application.Features.LeaveTypes.Requests.Commands;
using HR_Management.Application.Contracts.Persistence;
using HR_Management.Domain;
using MediatR;

namespace HR_Management.Application.Features.LeaveTypes.Handlers.Commands
{
    public class CreateLeaveTypesCommandHandler : IRequestHandler<CreateLeaveTypesCommand, int>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public CreateLeaveTypesCommandHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateLeaveTypesCommand request, CancellationToken cancellationToken)
        {
            var leaveType = _mapper.Map<LeaveType>(request.LeaveTypeDto);
            leaveType = await _leaveTypeRepository.Add(leaveType);
            return leaveType.Id;
        }
    }
}
