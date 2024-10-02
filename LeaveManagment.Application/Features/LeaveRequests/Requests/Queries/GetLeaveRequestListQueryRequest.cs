using LeaveManagment.Application.DTOs.LeaveRequest;
using MediatR;
using System.Collections.Generic;

namespace LeaveManagment.Application.Features.LeaveRequests.Requests.Queries
{
    public class GetLeaveRequestListQueryRequest : IRequest<List<LeaveRequestListDto>>
    {
    }
}
