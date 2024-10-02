using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LeaveManagment.Application.Models;

namespace LeaveManagment.Application.Contracts.Infrastructure
{
    public interface IEmailSender
    {
        Task<bool> SendEmail(Email email);
    }
}
