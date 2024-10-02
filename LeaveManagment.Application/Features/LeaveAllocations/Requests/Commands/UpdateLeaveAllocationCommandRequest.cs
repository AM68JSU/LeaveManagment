using LeaveManagment.Application.DTOs.LeaveAllocation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeaveManagment.Application.Features.LeaveAllocations.Requests.Commands
{
    public class UpdateLeaveAllocationCommandRequest:IRequest<Unit>
    {
        public int Id { get; set; }
        public UpdateLeaveAllocationDto UpdateLeaveAllocationDto { get; set; }

    }
}
