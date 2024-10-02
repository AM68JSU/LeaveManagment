using System;
using System.Collections.Generic;
using System.Text;

namespace LeaveManagment.Application.Exceptions
{
    public class BadRequestException:ApplicationException
    {
        public BadRequestException(string message, Exception ex = null) : base(message, ex)
        {

        }

    }
}
