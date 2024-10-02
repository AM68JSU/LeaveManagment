using LeaveManagment.Application.DTOs.LeaveRequest;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using LeaveManagment.Application.Features.LeaveRequests.Requests.Queries;
using AutoMapper;
using LeaveManagment.Application.Contracts.Persistence;

namespace LeaveManagment.Application.Features.LeaveRequests.Handlers.Queries
{
    public class GetLeaveRequestListQueryHandler :
        IRequestHandler<GetLeaveRequestListQueryRequest, List<LeaveRequestListDto>>
    {    
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _mapper;  
        public GetLeaveRequestListQueryHandler(ILeaveRequestRepository LeaveRequestRepository, IMapper mapper)
        {
            _leaveRequestRepository = LeaveRequestRepository;
            _mapper = mapper;
        }
        public async Task<List<LeaveRequestListDto>> Handle(GetLeaveRequestListQueryRequest request, CancellationToken cancellationToken)
        {  
            var leaveRequestList = await _leaveRequestRepository.GetLeaveRequestsWithDetails();
            return _mapper.Map<List<LeaveRequestListDto>>(leaveRequestList);
        }


 

    }

}
