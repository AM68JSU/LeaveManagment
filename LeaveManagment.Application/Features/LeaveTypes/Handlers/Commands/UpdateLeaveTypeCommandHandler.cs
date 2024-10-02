using AutoMapper;
using LeaveManagment.Application.DTOs.LeaveType.Validators;
using LeaveManagment.Application.Exceptions;
using LeaveManagment.Application.Features.LeaveTypes.Requests.Commands;
using LeaveManagment.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace LeaveManagment.Application.Features.LeaveTypes.Handlers.Commands
{
    public class UpdateLeaveTypeCommandHandler : IRequestHandler<UpdateLeaveTypeCommandRequest, Unit>
    {

        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public UpdateLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateLeaveTypeCommandRequest request, CancellationToken cancellationToken)
        {
            var valodator = new UpdateLeaveTypeDtoValidator();
            var validationResult = await valodator.ValidateAsync(request.UpdateLeaveTypeDto);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult);


            var leavetype = await _leaveTypeRepository.Get(request.UpdateLeaveTypeDto.Id);
            _mapper.Map(request.UpdateLeaveTypeDto, leavetype);

            await _leaveTypeRepository.Update(leavetype);

            return Unit.Value;
        }
    }
}
