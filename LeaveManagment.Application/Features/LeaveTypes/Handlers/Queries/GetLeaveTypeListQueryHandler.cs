using AutoMapper;
using LeaveManagment.Application.DTOs.LeaveType;
using LeaveManagment.Application.Features.LeaveTypes.Requests.Queries;
using LeaveManagment.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LeaveManagment.Application.Features.LeaveTypes.Handlers.Queries
{
    public class GetLeaveTypeListQueryHandler :
        IRequestHandler<GetLeaveTypeListQueryRequest, List<LeaveTypeDto>>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public GetLeaveTypeListQueryHandler(ILeaveTypeRepository leaveTypeRepository,IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }
        public async Task<List<LeaveTypeDto>> Handle(GetLeaveTypeListQueryRequest request, CancellationToken cancellationToken)
        {
           var leaveTypeList=await _leaveTypeRepository.GetAll();
            return _mapper.Map<List< LeaveTypeDto>>(leaveTypeList);
        }
    }
}
