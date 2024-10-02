using LeaveManagment.Application.DTOs.LeaveRequest;
using LeaveManagment.Application.DTOs.LeaveType;
using LeaveManagment.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeaveManagment.Application.Features.LeaveRequests.Requests.Commands
{
    public class CreateLeaveRequestCommandRequest : IRequest<BaseCommandResponse>
    {
        public LeaveRequestDto LeaveRequestDto { get; set; }
        public CreateLeaveRequestDto CreateLeaveRequestDto { get; set; }

        
    }
}
