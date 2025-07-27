using AutoMapper;
using HR_Management.Application.DTOs.LeaveAllocation;
using HR_Management.Application.Features.LeaveAllocation.Requests.Queries;
using HR_Management.Application.Contracts.Persistence;
using MediatR;

namespace HR_Management.Application.Features.LeaveAllocation.Handlers.Queries
{
    public class GetLeaveAllocationWithDetailsQueryHandler : IRequestHandler<GetLeaveAllocationWithDetailsQuery, LeaveAllocationDto>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly IMapper _mapper;

        public GetLeaveAllocationWithDetailsQueryHandler(ILeaveAllocationRepository leaveAllocationRepository, IMapper mapper)
        {
            _leaveAllocationRepository = leaveAllocationRepository;
            _mapper = mapper;
        }

        public async Task<LeaveAllocationDto> Handle(GetLeaveAllocationWithDetailsQuery query, CancellationToken cancellationToken)
        {
            var leaveAllocation = await _leaveAllocationRepository.GetLeaveAllocationWithDetails(query.Id);
            return _mapper.Map<LeaveAllocationDto>(leaveAllocation);
        }
    }
}
