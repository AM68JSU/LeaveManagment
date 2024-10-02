using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeaveManagment.Application.DTOs.LeaveType.Validators
{
    public class UpdateLeaveTypeDtoValidator:AbstractValidator<UpdateLeaveTypeDto>
    {
        public UpdateLeaveTypeDtoValidator()
        {
            Include(new LeaveTypeDtoValidator());
            RuleFor(p => p.Id).NotNull().WithMessage("{PropertyName} is required.");

        }
    }
}
