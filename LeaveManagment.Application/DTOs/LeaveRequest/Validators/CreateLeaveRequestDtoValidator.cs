using FluentValidation;
using LeaveManagment.Application.Contracts.Persistence;

namespace LeaveManagment.Application.DTOs.LeaveRequest.Validators
{
    public class CreateLeaveRequestDtoValidator : AbstractValidator<CreateLeaveRequestDto>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public CreateLeaveRequestDtoValidator(ILeaveTypeRepository leaveTypeRepository)
        {         
            _leaveTypeRepository = leaveTypeRepository;
            Include(new LeaveRequestDtoValidator(_leaveTypeRepository));
        }
    }
}
