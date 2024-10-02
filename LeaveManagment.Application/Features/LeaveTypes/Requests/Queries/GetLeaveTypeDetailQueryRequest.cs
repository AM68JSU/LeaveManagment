using LeaveManagment.Application.DTOs.LeaveType;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeaveManagment.Application.Features.LeaveTypes.Requests.Queries
{
    public class GetLeaveTypeDetailQueryRequest : IRequest<LeaveTypeDto>
    {
        public int Id { get; set; }
    }
}
