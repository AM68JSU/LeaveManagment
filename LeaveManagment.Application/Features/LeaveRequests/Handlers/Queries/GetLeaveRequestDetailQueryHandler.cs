using AutoMapper;
using LeaveManagment.Application.DTOs.LeaveRequest;
using LeaveManagment.Application.Features.LeaveRequests.Requests.Queries;
using LeaveManagment.Application.Contracts.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace LeaveManagment.Application.Features.LeaveRequests.Handlers.Queries
{
    public class GetLeaveRequestsDetailHandlerHandler :
        IRequestHandler<GetLeaveRequestDetailQueryRequest, LeaveRequestDto>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _mapper;

        public GetLeaveRequestsDetailHandlerHandler(ILeaveRequestRepository leaveRequestRepository,IMapper mapper)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
        }
        public async Task<LeaveRequestDto> Handle(GetLeaveRequestDetailQueryRequest request, CancellationToken cancellationToken)
        {
           var leaveRequests=await _leaveRequestRepository.GetLeaveRequestWithDetails(request.Id);
            return _mapper.Map<LeaveRequestDto>(leaveRequests);
        }
    }
}
