using AutoMapper;
using HR_Management.Application.DTOs.LeaveType;
using HR_Management.Application.Features.LeaveTypes.Requests.Queries;
using HR_Management.Application.Contracts.Persistence;
using MediatR;

namespace HR_Management.Application.Features.LeaveTypes.Handlers.Queries
{
    public class GetLeaveTypeListQueryHandler : IRequestHandler<GetLeaveTypeListQuery, List<LeaveTypeDto>>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public GetLeaveTypeListQueryHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }

        public async Task<List<LeaveTypeDto>> Handle(GetLeaveTypeListQuery query, CancellationToken cancellationToken)
        {
            var leaveTypes = await _leaveTypeRepository.GetAll();
            return _mapper.Map<List<LeaveTypeDto>>(leaveTypes);
        }
    }
}
