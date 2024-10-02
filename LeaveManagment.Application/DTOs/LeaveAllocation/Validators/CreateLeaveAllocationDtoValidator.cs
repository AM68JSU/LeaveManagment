using FluentValidation;
using LeaveManagment.Application.Contracts.Persistence;

namespace LeaveManagment.Application.DTOs.LeaveAllocation.Validators
{
    public class CreateLeaveAllocationDtoValidator : AbstractValidator<CreateLeaveAllocationDto>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public CreateLeaveAllocationDtoValidator(ILeaveTypeRepository leaveTypeRepository)
        {         
            _leaveTypeRepository = leaveTypeRepository;
            Include(new LeaveAllocationDtoValidator(_leaveTypeRepository));
        }
    }
}
