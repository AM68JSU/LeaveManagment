using AutoMapper;
using LeaveManagment.Application.Contracts.Persistence;
using LeaveManagment.Application.DTOs.LeaveType;
using LeaveManagment.Application.Features.LeaveTypes.Handlers.Queries;
using LeaveManagment.Application.Features.LeaveTypes.Requests.Queries;
using LeaveManagment.Application.Profiles;
using LeaveManagment.Application.UnitTests.Mocks;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagment.Application.UnitTests.LeaveTypes.Queries
{
    public class GetLeaveTypeRequestHandlerTests
    {
        private readonly IMapper _mapper;
        Mock<ILeaveTypeRepository> _mockrepository;
        public GetLeaveTypeRequestHandlerTests( )
        {
            _mockrepository = MockLeaveTypeRepository.GetLeaveTypeRepository();
            var mapperConfig = new MapperConfiguration(m =>
            {
                m.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
        }
        [Fact]
        public async Task GetLeaveTypeListTest()
        {
            var handler = new GetLeaveTypeListQueryHandler(_mockrepository.Object, _mapper);
            var result = await handler.Handle(new GetLeaveTypeListQueryRequest(), CancellationToken.None);
            result.ShouldBeOfType<List<LeaveTypeDto>>();
            result.Count.ShouldBe(2);
        }
    }
}
