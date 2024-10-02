using AutoMapper;
using FluentValidation.Results;
using LeaveManagment.Application.Exceptions;
using LeaveManagment.Application.Features.LeaveTypes.Requests.Commands;
using LeaveManagment.Application.Contracts.Persistence;
using LeaveManagment.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LeaveManagment.Application.Features.LeaveTypes.Handlers.Commands
{
    public class DeleteLeaveTypeCommandHandler : IRequestHandler<DeleteLeaveTypeCommandRequest,Unit>
    {

        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public DeleteLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }

        public async Task <Unit>Handle(DeleteLeaveTypeCommandRequest request, CancellationToken cancellationToken)
        {
            var leavetype = await _leaveTypeRepository.Get(request.Id);

            if (leavetype is null)
                throw new NotFoundException(nameof(Domain.LeaveType),request.Id);


            await _leaveTypeRepository.Delete(leavetype);

            return Unit.Value;
        }
    }
}
