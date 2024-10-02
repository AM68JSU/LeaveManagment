using LeaveManagment.Application.DTOs.Common;
using LeaveManagment.Application.DTOs.LeaveType;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeaveManagment.Application.DTOs.LeaveAllocation
{
    public class CreateLeaveAllocationDto:BaseDto, ILeaveAllocationDto
    {
        public int NumberOfDays { get; set; }
        public int LeaveTypeId { get; set; }
        public int Priod { get; set; }
    }
}
