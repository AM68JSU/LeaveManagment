using LeaveManagment.Application.DTOs.LeaveAllocation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeaveManagment.Application.Features.LeaveAllocations.Requests.Queries
{
    public class GetLeaveAllocationDetailQueryRequest : IRequest<LeaveAllocationDto>
    {
        public int Id { get; set; }
    }
}
