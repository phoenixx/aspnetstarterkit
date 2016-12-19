using System.Collections.Generic;
using Spa.StarterKit.React.ViewModels.User;

namespace Spa.StarterKit.React.ViewModels.Roles
{
    public class UserRolesViewModel
    {
        public IList<AccountViewModel> Accounts { get; set; }
        public IList<RoleViewModel> AvailableRoles { get; set; }
    }
}