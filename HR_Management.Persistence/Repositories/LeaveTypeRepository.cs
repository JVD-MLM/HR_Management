using HR_Management.Application.Persistence.Contracts;
using HR_Management.Domain;

namespace HR_Management.Persistence.Repositories
{
    public class LeaveTypeRepository : GenericRepository<LeaveType>, ILeaveTypeRepository
    {
        private readonly MyDbContext _dbContext;

        public LeaveTypeRepository(MyDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
