using HR_Management.Application.Contracts.Persistence;
using HR_Management.Domain;
using Microsoft.EntityFrameworkCore;

namespace HR_Management.Persistence.Repositories
{
    public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
    {
        private readonly MyDbContext _dbContext;

        public LeaveAllocationRepository(MyDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<LeaveAllocation>> GetLeaveAllocationListWithDetails()
        {
            var leaveAllocations = await _dbContext.LeaveAllocations.Include(l => l.LeaveType).ToListAsync();
            return leaveAllocations;
        }

        public async Task<LeaveAllocation> GetLeaveAllocationWithDetails(int id)
        {
            var leaveAllocation =
                await _dbContext.LeaveAllocations.Include(l => l.LeaveType).FirstOrDefaultAsync(l => l.Id == id);
            return leaveAllocation;
        }
    }
}
