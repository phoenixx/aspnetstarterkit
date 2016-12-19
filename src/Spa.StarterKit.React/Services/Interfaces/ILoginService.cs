using Spa.StarterKit.React.Models.Account;

namespace Spa.StarterKit.React.Services.Interfaces
{
    public interface ILoginService
    {
        LoginResult Login(string email, string password);
        void Logout();
    }
}