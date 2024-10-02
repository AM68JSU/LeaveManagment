using LeaveManagment.Application.DTOs.LeaveType;
using LeaveManagment.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeaveManagment.Application.Features.LeaveTypes.Requests.Commands
{
    public class CreateLeaveTypeCommandRequest:IRequest<BaseCommandResponse>
    {
        public CreateLeaveTypeDto CreateLeaveTypeDto { get; set; }
    }
}
