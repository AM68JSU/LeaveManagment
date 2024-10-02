using LeaveManagment.Application.DTOs.LeaveAllocation;
using MediatR;

namespace LeaveManagment.Application.Features.LeaveAllocations.Requests.Commands
{
    public class CreateLeaveAllocationCommandRequest : IRequest<int>
    {
        public CreateLeaveAllocationDto CreateLeaveAllocationDto { get; set; }

    }
}
