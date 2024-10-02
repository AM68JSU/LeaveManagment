using AutoMapper;
using LeaveManagment.Application.DTOs.LeaveRequest.Validators;
using LeaveManagment.Application.DTOs.LeaveType.Validators;
using LeaveManagment.Application.Exceptions;
using LeaveManagment.Application.Features.LeaveRequests.Requests.Commands;
using LeaveManagment.Application.Contracts.Persistence;
using LeaveManagment.Application.Responses;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using LeaveManagment.Application.Contracts.Infrastructure;
using LeaveManagment.Application.Models;

namespace LeaveManagment.Application.Features.LeaveRequests.Handlers.Commands
{
    public class CreateLeaveRequestCommandHandler : IRequestHandler<CreateLeaveRequestCommandRequest, BaseCommandResponse>
    {

        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IEmailSender _emailSender;

        public CreateLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper, ILeaveTypeRepository leaveTypeRepository, IEmailSender emailSender)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
            _leaveTypeRepository = leaveTypeRepository;
            _emailSender = emailSender;
        }

        public async Task<BaseCommandResponse> Handle(CreateLeaveRequestCommandRequest request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            var validator = new CreateLeaveRequestDtoValidator(_leaveTypeRepository);
            var validationResult = await validator.ValidateAsync(request.CreateLeaveRequestDto);

            if (!validationResult.IsValid)
            {
                // throw new ValidationException(validationResult);
                response.Success = false;
                response.Message = "Creation leaverequest feiled";
                response.Errors = validationResult.Errors.Select(c => c.ErrorMessage).ToList();

            }


            var leaveRequest = _mapper.Map<Domain.LeaveRequest>(request.LeaveRequestDto);
            leaveRequest = await _leaveRequestRepository.Add(leaveRequest);


            response.Success = true;
            response.Message = "Creation leaverequest successful";
            response.Id = leaveRequest.Id;
           
            var email = new Email
            {
                To = "Akbarmazrouei@gmail.com",
                Subject = "Leave request submitted.",
                Body = $"Your leave request for {request.LeaveRequestDto.StartDate} To {request.LeaveRequestDto.EndDate} has been submitted."
            };
            try
            {
                await _emailSender.SendEmail(email);
            }
            catch (Exception)
            {
                //log
            }
            return response;
        }
    }
}
