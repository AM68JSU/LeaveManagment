using Hanssens.Net;
using LeaveManagment.Mvc.Contratcs;
using System.Net.Http.Headers;

namespace LeaveManagment.Mvc.Services.Base
{
    public class BaseHttpService
    {
        protected readonly IClient _client;
        protected readonly ILocalStorageService _localStorageService;

        public BaseHttpService(IClient client, ILocalStorageService localStorageService)
        {
            _client = client;
            _localStorageService = localStorageService;
        }

        protected Response<Guid> ConvertApiExceptions<Guid>(ApiException exception)
        {
            if (exception.StatusCode == 400)
            {
                return new Response<Guid>() { Message = "Validation errors have occured.", ValidationErrors = exception.Response, Success = false };
            }
            else if (exception.StatusCode == 404)
            {
                return new Response<Guid>() { Message = "Not found ...", Success = false };
            }
            else
            {
                return new Response<Guid>() { Message = "Something went wrong,try again", ValidationErrors = exception.Response, Success = false };
            }
        }

        protected void AddBearerToken()
        {
            if (_localStorageService.Exists("token")) 
            {
                _client.HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", _localStorageService.GetStorageValue<string>("token"));
            }
        }
    }
}
