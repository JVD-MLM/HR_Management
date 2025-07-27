using HR_Management.Domain;

namespace HR_Management.Application.Persistence.Contracts
{
    public interface ILeaveAllocationRepository : IGenericRepository<LeaveAllocation>
    {
        public Task<List<LeaveAllocation>> GetLeaveAllocationListWithDetails();
        public Task<LeaveAllocation> GetLeaveAllocationWithDetails(int id);
    }
}
