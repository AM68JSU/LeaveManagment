using LeaveManagment.Application.DTOs.LeaveType;
using MediatR;
using System;
using System.Collections.Generic;
using MediatR;

namespace LeaveManagment.Application.Features.LeaveTypes.Requests.Commands
{
    public class DeleteLeaveTypeCommandRequest : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
