using FluentValidation;
using LeaveManagment.Application.Contracts.Persistence;

namespace LeaveManagment.Application.DTOs.LeaveAllocation.Validators
{
    public class UpdateLeaveAllocationDtoValidator : AbstractValidator<UpdateLeaveAllocationDto>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public UpdateLeaveAllocationDtoValidator(ILeaveTypeRepository leaveTypeRepository)
        {         
            _leaveTypeRepository = leaveTypeRepository;
            Include(new LeaveAllocationDtoValidator(_leaveTypeRepository));
            RuleFor(p => p.Id).NotNull().WithMessage("{PropertyName} is required");
        }
    }
}
