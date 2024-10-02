using AutoMapper;
using LeaveManagment.Application.Contracts.Persistence;
using LeaveManagment.Application.DTOs.LeaveType;
using LeaveManagment.Application.Features.LeaveTypes.Handlers.Commands;
using LeaveManagment.Application.Features.LeaveTypes.Handlers.Queries;
using LeaveManagment.Application.Features.LeaveTypes.Requests.Commands;
using LeaveManagment.Application.Features.LeaveTypes.Requests.Queries;
using LeaveManagment.Application.Profiles;
using LeaveManagment.Application.Responses;
using LeaveManagment.Application.UnitTests.Mocks;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagment.Application.UnitTests.LeaveTypes.Commands
{
    public class CreateLeaveTypeCommandHandlerTests
    {
        private readonly IMapper _mapper;
        Mock<ILeaveTypeRepository> _mockrepository;
        CreateLeaveTypeDto _createLeaveTypeDto;
        public CreateLeaveTypeCommandHandlerTests()
        {
            _mockrepository = MockLeaveTypeRepository.GetLeaveTypeRepository();
            var mapperConfig = new MapperConfiguration(m =>
            {
                m.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();

            _createLeaveTypeDto = new CreateLeaveTypeDto
            {
                Id=3,
                DefaultDay=18,
                Name="Test"
            };
        }
        [Fact]
        public async Task CreateLeaveTypeTest()
        {
            var handler = new CreateLeaveTypeCommandHandler(_mockrepository.Object, _mapper);
            var result = await handler.Handle(new CreateLeaveTypeCommandRequest() { CreateLeaveTypeDto= _createLeaveTypeDto }, CancellationToken.None);
            result.ShouldBeOfType<BaseCommandResponse>();

            var leavetype = await _mockrepository.Object.GetAll();
            leavetype.Count.ShouldBe(3);
        }
    }
}
