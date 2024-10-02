using LeaveManagment.Application.DTOs.LeaveAllocation;
using LeaveManagment.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeaveManagment.Application.Features.LeaveAllocations.Requests.Queries
{
    public class GetLeaveAllocationListQueryRequest : IRequest<List<LeaveAllocationDto>>
    {
    }
}
