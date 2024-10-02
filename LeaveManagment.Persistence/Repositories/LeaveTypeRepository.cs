using LeaveManagment.Application.Contracts.Persistence;
using LeaveManagment.Domain;
using LeaveManagment.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeaveManagment.Persistence.Repositories
{
    public class LeaveTypeRepository : GenericRepository<LeaveType>, ILeaveTypeRepository
    {
        private readonly LeaveManagmentDbContext _context;

        public LeaveTypeRepository(LeaveManagmentDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
