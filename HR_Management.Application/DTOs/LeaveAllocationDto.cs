using HR_Management.Application.DTOs.Common;

namespace HR_Management.Application.DTOs
{
    public class LeaveAllocationDto : BaseDto
    {
        public int LeaveTypeId { get; set; }
        public int NumberOfDays { get; set; }
        public int Period { get; set; }




        public LeaveTypeDto LeaveType { get; set; }
    }
}
