using HR_Management.Application.DTOs.Common;
using HR_Management.Application.DTOs.LeaveType;

namespace HR_Management.Application.DTOs.LeaveRequest
{
    public class LeaveRequestListDto : BaseDto
    {
        public DateTime RequestedDate { get; set; }
        public bool? Approved { get; set; }




        public LeaveTypeDto LeaveType { get; set; }
    }
}
