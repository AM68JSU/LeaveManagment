using LeaveManagment.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LeaveManagment.Application.Contracts.Persistence
{
    public interface ILeaveAllocationRepository:IGenericRepository<LeaveAllocation>
    {
        Task<LeaveAllocation> GetLeaveAllocationWithDetails(int id);
        Task<List< LeaveAllocation>> GetLeaveAllocationsWithDetails();

    }
}
