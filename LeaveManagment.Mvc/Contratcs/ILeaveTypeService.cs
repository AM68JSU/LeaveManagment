using LeaveManagment.Mvc.Models.LeaveTypes;
using LeaveManagment.Mvc.Services.Base;

namespace LeaveManagment.Mvc.Contratcs
{
    public interface ILeaveTypeService
    {
        Task<List<LeaveTypeVM>> GetLeaveTypes();
        Task<LeaveTypeVM> GetLeaveTypeDetails(int id);

        Task<Response<int>> CreateLeaveType(CreateLeaveTypeVM createLeaveTypeVM);
        Task<Response<int>> UpdateLeaveType(int id, UpdateLeaveTypeVM updateLeaveTypeVM);
        Task<Response<int>> DeleteLeaveType(int id);

    }
}
