using LeaveManagment.Mvc.Contratcs;
using LeaveManagment.Mvc.Models.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LeaveManagment.Mvc.Controllers
{
    public class UsersController : Controller
    {
        private readonly IAuthenticateService _authenticateService;

        public UsersController(IAuthenticateService authenticateService)
        {
            _authenticateService = authenticateService;
        }

        #region Login

        // GET: UsersController/Login
        public IActionResult Login(string returnUrl = null)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM login, string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");

            var isLoggedIn = await _authenticateService.AuthenticateAsync(login.Email, login.Password);
            if (isLoggedIn)
            {
                return LocalRedirect(returnUrl);
            }
            ModelState.AddModelError("", "Login feild. Try again.");
            return View(login);
        }
        #endregion

        #region Logout
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
          await  _authenticateService.LogoutAsync();
            return LocalRedirect("/Users/Login");
        }
        #endregion

        #region Register


        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (!ModelState.IsValid)
            {
                return View(registerVM);
            }
            var isRegistered=await _authenticateService.RegisterAsync(registerVM);
            if (isRegistered)
            {
                return LocalRedirect("/");
            }

            return View(registerVM);
        }
        #endregion


    }
}
