using LeaveManagment.Application.DTOs.LeaveRequest;
using MediatR;

namespace LeaveManagment.Application.Features.LeaveRequests.Requests.Queries
{
    public class GetLeaveRequestDetailQueryRequest : IRequest<LeaveRequestDto>
    {
        public int Id { get; set; }
    }
}
