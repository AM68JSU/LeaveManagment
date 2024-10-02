using LeaveManagment.Application.DTOs.Common;
using LeaveManagment.Application.DTOs.LeaveType;

namespace LeaveManagment.Application.DTOs.LeaveAllocation
{
    public class LeaveAllocationDto : BaseDto, ILeaveAllocationDto
    {
        public int NumberOfDays { get; set; }
        public LeaveTypeDto LeaveType { get; set; }
        public int LeaveTypeId { get; set; }
        public int Priod { get; set; }

    }
}
