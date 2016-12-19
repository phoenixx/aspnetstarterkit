using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using MPD.Electio.SDK.NetCore.DataTypes.Security;
using MPD.Electio.SDK.NetCore.Internal.DataTypes.Security;
using MPD.Electio.SDK.NetCore.Internal.Interfaces;
using Spa.StarterKit.React.Models.Account;
using Spa.StarterKit.React.Services.Interfaces;

namespace Spa.StarterKit.React.Services
{
    public class LoginService : ILoginService
    {
        private readonly IAuthenticationService _authenticationService;

        public LoginService(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public LoginResult Login(string email, string password)
        {
            var authenticationResult = _authenticationService.AuthenticateAccount(new AuthenticateAccountRequest()
            {
                EmailAddress = email,
                Password = password
            });

            if (authenticationResult.IsAuthenticated == false)
            {
                return new LoginResult()
                {
                    IsAuthenticated = false,
                    Message = authenticationResult.AuthenticationFailureMessage
                };
            }

            var permissions = GetDistinctPermissions(authenticationResult);
            var claims = PermissionsToClaims(permissions);
            
            var userIdentity = new ClaimsIdentity(claims, "Electio");

            var userPrincipal = new ClaimsPrincipal(userIdentity);

            return new LoginResult()
            {
                ClaimsPrincipal = userPrincipal,
                IsAuthenticated = true,
                Message = string.Empty
            };
        }


        private static IEnumerable<Permission> GetDistinctPermissions(AuthenticateAccountResponse authResponse)
        {
            return authResponse.Account.Roles.Select(r => r).SelectMany(p => p.Permissions).Distinct().ToList();
        }

        private static IEnumerable<Claim> PermissionsToClaims(IEnumerable<Permission> permissions)
        {
            return permissions.Select(
                permission => 
                new Claim(permission.Key, ClaimValueTypes.String)).ToList();
        }
    }
}