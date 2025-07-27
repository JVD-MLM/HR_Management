using HR_Management.Application.Features.LeaveTypes.Requests.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HR_Management.Application.Persistence.Contracts;

namespace HR_Management.Application.Features.LeaveTypes.Handlers.Commands
{
    public class DeleteLeaveTypesCommandHandler : IRequestHandler<DeleteLeaveTypesCommand, Unit>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public DeleteLeaveTypesCommandHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteLeaveTypesCommand request, CancellationToken cancellationToken)
        {
            var leaveType = await _leaveTypeRepository.Get(request.Id);
            await _leaveTypeRepository.Update(leaveType);
            return Unit.Value;
        }
    }
}
