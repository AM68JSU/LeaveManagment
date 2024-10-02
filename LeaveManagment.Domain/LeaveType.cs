using LeaveManagment.Domain.Common;

namespace LeaveManagment.Domain
{
    public class LeaveType: BaseEntity
    {
        public string Name { get; set; }
        public int DefaultDay { get; set; }
        public string? Description { get; set; }

    }
}
