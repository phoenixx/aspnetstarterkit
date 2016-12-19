using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Authentication;
using Microsoft.AspNetCore.Mvc;
using MPD.Electio.SDK.NetCore.Internal.DataTypes.Security;
using MPD.Electio.SDK.NetCore.Internal.Interfaces;
using Spa.StarterKit.React.Models.Account;

namespace Spa.StarterKit.React.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly IAuthenticationService _authenticationService;

        public AccountController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
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

            if (string.Compare(model.Password, "password", StringComparison.OrdinalIgnoreCase) != 0)
            {
                ViewBag.HasError = true;
                ViewBag.Error = "Invalid username or password";
                return View("~/Views/Account/Login.cshtml", model);
            }

            var authDetails = _authenticationService.AuthenticateAccount(new AuthenticateAccountRequest()
            {
                EmailAddress = model.Email,
                Password = model.Password
            });

            if (authDetails.IsAuthenticated == false)
            {
                ViewBag.HasError = true;
                ViewBag.Error = "Invalid username or password";
                return View("~/Views/Account/Login.cshtml", model);
            }
            

            const string issuer = "https://www.electioapp.com";

            var claims = new List<Claim> {
                new Claim(ClaimTypes.Name, "Michael", ClaimValueTypes.String, issuer),
                new Claim(ClaimTypes.Surname, "Rose", ClaimValueTypes.String, issuer),
                new Claim(ClaimTypes.Country, "UK", ClaimValueTypes.String, issuer),
                new Claim("CustomPermission", "SuperAdmin", ClaimValueTypes.String, issuer)
            };

            var userIdentity = new ClaimsIdentity(claims, "Passport");

            var userPrincipal = new ClaimsPrincipal(userIdentity);

            await HttpContext.Authentication.SignInAsync("Cookie", userPrincipal,
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