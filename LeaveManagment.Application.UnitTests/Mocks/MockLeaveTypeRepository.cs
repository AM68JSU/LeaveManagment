using LeaveManagment.Application.Contracts.Persistence;
using LeaveManagment.Domain;
using LeaveManagment.Persistence.Repositories;
using Moq;
using System;


namespace LeaveManagment.Application.UnitTests.Mocks
{
    public static class MockLeaveTypeRepository
    {
        public  static Mock<ILeaveTypeRepository> GetLeaveTypeRepository()
        {
            var leaveTypes = new List<LeaveType>() 
            { new LeaveType { Id = 1, DefaultDay = 10, Name = "Test vacation" },
               new LeaveType { Id = 2, DefaultDay = 15, Name = "Test Sick" } };

            var mockLeaveTypeRepository = new Mock<ILeaveTypeRepository>();

            mockLeaveTypeRepository.Setup(c => c.GetAll()).ReturnsAsync(leaveTypes);

            mockLeaveTypeRepository.Setup(c=> c.Add(It.IsAny<LeaveType>())).ReturnsAsync((LeaveType leaveType) =>
            {
                leaveTypes.Add(leaveType);
                return leaveType;
            });

            return mockLeaveTypeRepository;

        }
    }
}
