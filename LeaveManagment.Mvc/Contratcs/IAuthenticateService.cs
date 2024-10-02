using LeaveManagment.Mvc.Models.Identity;

namespace LeaveManagment.Mvc.Contratcs
{
    public interface IAuthenticateService
    {
        Task<bool> AuthenticateAsync(string email,string password);
        Task<bool> RegisterAsync(RegisterVM registerVM);
        Task LogoutAsync();

    }
}
