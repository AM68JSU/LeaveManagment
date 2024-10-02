using MediatR;

namespace LeaveManagment.Application.Features.LeaveRequests.Requests.Commands
{
    public class DeleteLeaveRequestCommandRequest : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
