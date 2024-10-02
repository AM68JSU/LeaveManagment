using AutoMapper;
using LeaveManagment.Mvc.Contratcs;
using LeaveManagment.Mvc.Models.LeaveTypes;
using LeaveManagment.Mvc.Services.Base;
namespace LeaveManagment.Mvc.Services
{
    public class LeaveTypeService : BaseHttpService, ILeaveTypeService
    {
        private readonly IMapper _mapper;
        private readonly IClient _client;

        public LeaveTypeService(IMapper mapper, IClient client, ILocalStorageService localStorageService) : base
            (client, localStorageService)
        {
            _mapper = mapper;
            _client = client;
        }

        public async Task<Response<int>> CreateLeaveType(CreateLeaveTypeVM createLeaveTypeVM)
        {
            try
            {
                var response = new Response<int>();
                CreateLeaveTypeDto createLeaveTypeDto = _mapper.Map<CreateLeaveTypeDto>(createLeaveTypeVM);
                AddBearerToken();

                var apiResponse = await _client.LeaveTypesPOSTAsync(createLeaveTypeDto);

                if (apiResponse.Success)
                {
                    response.Data = apiResponse.Id;
                    response.Success = true;
                }
                else
                {
                    foreach (var error in apiResponse.Errors)
                    {
                        response.ValidationErrors += error + Environment.NewLine;
                    }
                }
                return response;
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<int>(ex);
            }

        }


        public async Task<Response<int>> DeleteLeaveType(int id)
        {
            try
            {
                AddBearerToken();

                await _client.LeaveTypesDELETEAsync(id);
                return new Response<int> { Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<int>(ex);

            }
        }

        public async Task<LeaveTypeVM> GetLeaveTypeDetails(int id)
        {
            AddBearerToken();
            var leaveType = await _client.LeaveTypesGETAsync(id);
            return _mapper.Map<LeaveTypeVM>(leaveType);
        }

        public async Task<List<LeaveTypeVM>> GetLeaveTypes()
        {
            AddBearerToken();

            var leaveTypes = await _client.LeaveTypesAllAsync();
            return _mapper.Map<List<LeaveTypeVM>>(leaveTypes);
        }


        public async Task<Response<int>> UpdateLeaveType(int id, UpdateLeaveTypeVM updateLeaveTypeVM)
        {
            try
            {
                AddBearerToken();

                UpdateLeaveTypeDto updateLeaveTypeDto = _mapper.Map<UpdateLeaveTypeDto>(updateLeaveTypeVM);
                await _client.LeaveTypesPUTAsync(id, updateLeaveTypeDto);
                return new Response<int> { Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<int>(ex);

            }
        }

    }
}
