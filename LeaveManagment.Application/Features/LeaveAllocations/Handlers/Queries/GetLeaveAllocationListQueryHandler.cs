using AutoMapper;
using LeaveManagment.Application.DTOs.LeaveAllocation;
using LeaveManagment.Application.Features.LeaveAllocations.Requests.Queries;
using LeaveManagment.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LeaveManagment.Application.Features.LeaveAllocations.Handlers.Queries
{
    public class GetLeaveAllocationListQueryHandler :
        IRequestHandler<GetLeaveAllocationListQueryRequest, List<LeaveAllocationDto>>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly IMapper _mapper;

        public GetLeaveAllocationListQueryHandler(ILeaveAllocationRepository leaveAllocationRepository,IMapper mapper)
        {
            _leaveAllocationRepository = leaveAllocationRepository;
            _mapper = mapper;
        }
        public async Task<List<LeaveAllocationDto>> Handle(GetLeaveAllocationListQueryRequest request, CancellationToken cancellationToken)
        {
           var leaveAllocationList=await _leaveAllocationRepository.GetAll();
            return _mapper.Map<List< LeaveAllocationDto>>(leaveAllocationList);
        }
    }
}
