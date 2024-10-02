using AutoMapper;
using LeaveManagment.Application.DTOs.LeaveType.Validators;
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
using LeaveManagment.Application.Responses;
using System.Linq;

namespace LeaveManagment.Application.Features.LeaveTypes.Handlers.Commands
{
    public class CreateLeaveTypeCommandHandler : IRequestHandler<CreateLeaveTypeCommandRequest, BaseCommandResponse>
    {

        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public CreateLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateLeaveTypeCommandRequest request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            var valodator = new CreateLeaveTypeDtoValidator();
            var validationResult = await valodator.ValidateAsync(request.CreateLeaveTypeDto);

            if (!validationResult.IsValid)
            {
                // throw new ValidationException(validationResult);
                response.Success = false;
                response.Message = "Creation field.";
                response.Errors = validationResult.Errors.Select(e=>e.ErrorMessage).ToList();

            }
            else
            {
                var leavetype = _mapper.Map<LeaveType>(request.CreateLeaveTypeDto);
                leavetype = await _leaveTypeRepository.Add(leavetype);
                response.Success = true;
                response.Message = "Creation Successful.";
                response.Id= leavetype.Id;
            }
            return response;
        }
    }
}
