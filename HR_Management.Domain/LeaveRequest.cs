using HR_Management.Domain.Common;

namespace HR_Management.Domain
{
    public class LeaveRequest : BaseDomainEntity
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int LeaveTypeId { get; set; }
        public DateTime RequestedDate { get; set; }
        public DateTime? DateActioned { get; set; }
        public string RequestComment { get; set; }
        public bool? Approved { get; set; }
        public bool Canceled { get; set; }




        public LeaveType LeaveType { get; set; }
    }
}
