using System.Security.Claims;

namespace Spa.StarterKit.React.Models.Account
{
    public class LoginResult
    {
        public bool IsAuthenticated { get; set; }
        public string Message { get; set; }
        public ClaimsPrincipal ClaimsPrincipal { get; set; }
    }
}