using AutoMapper;
using HR_Management.Application.DTOs.LeaveRequest;
using HR_Management.Application.Features.LeaveRequest.Requests.Queries;
using HR_Management.Application.Contracts.Persistence;
using MediatR;

namespace HR_Management.Application.Features.LeaveRequest.Handlers.Queries
{
    public class GetLeaveRequestListWithDetailsQueryHandler : IRequestHandler<GetLeaveRequestListWithDetailsQuery, List<LeaveRequestDto>>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _mapper;

        public GetLeaveRequestListWithDetailsQueryHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
        }

        public async Task<List<LeaveRequestDto>> Handle(GetLeaveRequestListWithDetailsQuery request, CancellationToken cancellationToken)
        {
            var leaveRequests = await _leaveRequestRepository.GetLeaveRequestListWithDetails();
            return _mapper.Map<List<LeaveRequestDto>>(leaveRequests);
        }
    }
}
