using HR_Management.Domain;

namespace HR_Management.Application.Contracts.Persistence
{
    public interface ILeaveRequestRepository : IGenericRepository<LeaveRequest>
    {
        public Task<List<LeaveRequest>> GetLeaveRequestListWithDetails();
        public Task<LeaveRequest> GetLeaveRequestWithDetails(int id);
    }
}
