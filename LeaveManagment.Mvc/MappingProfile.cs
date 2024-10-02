using AutoMapper;
using LeaveManagment.Mvc.Models.LeaveTypes;
using LeaveManagment.Mvc.Services.Base;

namespace LeaveManagment.Mvc
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<UpdateLeaveTypeDto, UpdateLeaveTypeVM>().ReverseMap();
            CreateMap<CreateLeaveTypeDto, CreateLeaveTypeVM>().ReverseMap();
            CreateMap<LeaveTypeDto, LeaveTypeVM>().ReverseMap();

        }
    }
}
