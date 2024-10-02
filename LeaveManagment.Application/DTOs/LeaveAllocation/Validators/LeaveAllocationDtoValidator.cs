using FluentValidation;
using LeaveManagment.Application.Contracts.Persistence;
using System;

namespace LeaveManagment.Application.DTOs.LeaveAllocation.Validators
{
    public class LeaveAllocationDtoValidator : AbstractValidator<ILeaveAllocationDto>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public LeaveAllocationDtoValidator(ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;

            RuleFor(p=>p.NumberOfDays). GreaterThan(0).WithMessage("{PropertyName} must  greater  then{ComparisonValue}.");

            RuleFor(p => p.Priod).GreaterThanOrEqualTo(DateTime.Now.Year).WithMessage("{PropertyName} must be after  {ComparisonValue}.");


            RuleFor(p => p.LeaveTypeId)
                .GreaterThan(0)
                .MustAsync(async (id, token) =>
                {
                    var leaveTypeExist = await _leaveTypeRepository.Exist(id);
                    return !leaveTypeExist;
                })
                .WithMessage("{PropertyName} does not exist.");

        }
    }
}
