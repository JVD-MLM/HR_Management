using AutoMapper;
//using HR_Management.Application.Contracts.Infrastructure;
using HR_Management.Application.Features.LeaveRequest.Requests.Commands;
using HR_Management.Application.Contracts.Persistence;
using HR_Management.Application.Models;
using MediatR;

namespace HR_Management.Application.Features.LeaveRequest.Handlers.Commands
{
    public class CreateLeaveRequestCommandHandler : IRequestHandler<CreateLeaveRequestCommand, int>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _mapper;
        //private readonly IEmailSender _emailSender;

        public CreateLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper /*IEmailSender emailSender*/)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
            //_emailSender = emailSender;
        }

        public async Task<int> Handle(CreateLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            var leaveRequest = _mapper.Map<Domain.LeaveRequest>(request.LeaveRequestDto);
            leaveRequest = await _leaveRequestRepository.Add(leaveRequest);

            var email = new Email()
            {
                To = "test@test.com",
                Subject = "test",
                Body = "test"
            };
            //await _emailSender.SendEmail(email);

            return leaveRequest.Id;
        }
    }
}
