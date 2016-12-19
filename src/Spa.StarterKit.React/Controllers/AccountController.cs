using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Authentication;
using Microsoft.AspNetCore.Mvc;
using Spa.StarterKit.React.Models.Account;
using Spa.StarterKit.React.Services.Interfaces;

namespace Spa.StarterKit.React.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly ILoginService _loginService;

        public AccountController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpGet]
        [Route("/Account/Login")]
        public IActionResult Index(string ReturnUrl = null)
        {
            return View("~/Views/Account/Login.cshtml", new LoginModel()
            {
                ReturnUrl = ReturnUrl
            });
        }

        [HttpPost]
        [Route("/Account/Login")]
        public async Task<IActionResult> ProcessLogin(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.HasError = true;
                ViewBag.Error = ModelState.Values.First(v => v.Errors.Any()).Errors.First(e => !string.IsNullOrWhiteSpace(e.ErrorMessage)).ErrorMessage;
                return View("~/Views/Account/Login.cshtml", model);
            }

            var loginResponse = _loginService.Login(model.Email, model.Password);

            if (loginResponse.IsAuthenticated == false)
            {
                ViewBag.HasError = true;
                ViewBag.Error = "Invalid username or password";
                return View("~/Views/Account/Login.cshtml", model);
            }

            await HttpContext.Authentication.SignInAsync("Cookie", loginResponse.ClaimsPrincipal,
                new AuthenticationProperties
                {
                    ExpiresUtc = DateTime.UtcNow.AddMinutes(20),
                    IsPersistent = false,
                    AllowRefresh = false
                });

            return RedirectToLocal(model.ReturnUrl);
        }

        public IActionResult Forbidden()
        {
            return View();
        }

        [Route("/Account/logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.Authentication.SignOutAsync("Cookie");
            return RedirectToLocal("/");
        }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }

            return RedirectToAction("Index", "Home");
        }
    }
}