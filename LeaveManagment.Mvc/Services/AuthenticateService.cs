using Hanssens.Net;
using LeaveManagment.Mvc.Contratcs;
using LeaveManagment.Mvc.Models.Identity;
using LeaveManagment.Mvc.Services.Base;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace LeaveManagment.Mvc.Services
{
    public class AuthenticateService : BaseHttpService, IAuthenticateService
    {

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly JwtSecurityTokenHandler _jwtSecurityTokenHandler;
        private readonly ILocalStorage _localStorage;


        public AuthenticateService(IHttpContextAccessor httpContextAccessor, IClient client, ILocalStorageService localStorageService, ILocalStorage localStorage) : base(client, localStorageService)
        {
            _httpContextAccessor = httpContextAccessor;
            _jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            _localStorage = localStorage;
        }

        public async Task<bool> AuthenticateAsync(string email, string password)
        {
            try
            {
                AuthRequest authRequest = new AuthRequest()
                {
                    Email = email,
                    Password = password
                };
                AuthResponse authResponse = await _client.LoginAsync(authRequest);
                if (authResponse.Token != string.Empty)
                {
                    var tokenContent = _jwtSecurityTokenHandler.ReadJwtToken(authResponse.Token);
                    var claims = ParseClaim(tokenContent);
                    var user = new ClaimsPrincipal(new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme));

                    var login = _httpContextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, user);

                    _localStorageService.SetStorageValue("token", authResponse.Token);
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        #region LogoutAsync
        public async Task LogoutAsync()
        {
            _localStorageService.ClearStorage(new List<string>() { "token" });
            await _httpContextAccessor.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }

        #endregion

        #region RegisterAsync

        public async Task<bool> RegisterAsync(RegisterVM registerVM)
        {
            RegisterationRequest registerationRequest = new RegisterationRequest() { Email = registerVM.Email, FirstName = registerVM.FirstName, LastName = registerVM.LastName, Password = registerVM.Password ,UserName=registerVM.UserName};
            RegisterationResponse registerationResponse = await _client.RegisterAsync(registerationRequest);

            if (!string.IsNullOrEmpty(registerationResponse.UserId))
            {
                return true;
            }
            return false;

        }
        #endregion


        private IList<Claim> ParseClaim(JwtSecurityToken token)
        {

            var claims = token.Claims.ToList();
            claims.Add(new Claim(ClaimTypes.Name, token.Subject));
            return claims;
        }
    }
}
