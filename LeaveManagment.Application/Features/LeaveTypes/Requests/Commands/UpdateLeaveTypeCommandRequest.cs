using LeaveManagment.Application.DTOs.LeaveType;
using MediatR;
using System;
using System.Collections.Generic;
using MediatR;

namespace LeaveManagment.Application.Features.LeaveTypes.Requests.Commands
{
    public class UpdateLeaveTypeCommandRequest:IRequest<Unit>
    {
        public int Id { get; set; }
        public LeaveTypeDto LeaveTypeDto { get; set; }
        public UpdateLeaveTypeDto UpdateLeaveTypeDto { get; set; }

    }
}
