using HR_Management.Domain.Common;

namespace HR_Management.Domain
{
    public class LeaveAllocation : BaseDomainEntity
    {
        public int LeaveTypeId { get; set; }
        public int NumberOfDays { get; set; }
        public int Period { get; set; }




        public LeaveType LeaveType { get; set; }
    }
}
