using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeaveManagment.Application.DTOs.LeaveType.Validators
{
    public class CreateLeaveTypeDtoValidator:AbstractValidator<CreateLeaveTypeDto>
    {
        public CreateLeaveTypeDtoValidator()
        {
            Include(new LeaveTypeDtoValidator());
        }
    }
}
