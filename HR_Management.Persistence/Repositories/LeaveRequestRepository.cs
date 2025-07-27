using HR_Management.Application.Persistence.Contracts;
using HR_Management.Domain;
using Microsoft.EntityFrameworkCore;

namespace HR_Management.Persistence.Repositories
{
    public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
    {
        private readonly MyDbContext _dbContext;

        public LeaveRequestRepository(MyDbContext dbContext, MyDbContext context) : base(dbContext)
        {
            _dbContext = context;
        }
        public async Task<List<LeaveRequest>> GetLeaveRequestListWithDetails()
        {
            var leaveRequests = await _dbContext.LeaveRequests.Include(l => l.LeaveType).ToListAsync();
            return leaveRequests;
        }

        public async Task<LeaveRequest> GetLeaveRequestWithDetails(int id)
        {
            var leaveRequest =
                await _dbContext.LeaveRequests.Include(l => l.LeaveType).FirstOrDefaultAsync(l => l.Id == id);
            return leaveRequest;
        }
    }
}
