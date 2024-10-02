using FluentValidation;

namespace LeaveManagment.Application.DTOs.LeaveType.Validators
{
    public class LeaveTypeDtoValidator : AbstractValidator<ILeaveTypeDto>
    {
        public LeaveTypeDtoValidator()
        {
            RuleFor(p => p.Name)
              .NotEmpty().WithMessage("{PropertyName} is required")
              .NotNull()
              .MaximumLength(50).WithMessage("{PropertyName} must not exced 50");

            RuleFor(p => p.DefaultDay)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .GreaterThan(0).WithMessage("{PropertyName} must be at least 1.")
                .LessThan(100).WithMessage("{PropertyName}  must be less then 100.");
        }
    }
}
