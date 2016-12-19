using System.Collections.Generic;
using MPD.Electio.SDK.NetCore.DataTypes.Security.v1_1;
using Spa.StarterKit.React.Models;
using Spa.StarterKit.React.ViewModels.User;

namespace Spa.StarterKit.React.ViewModels.Roles
{
    public class RoleUsersViewModel : SortableModel
    {
        public Role Role { get; set; }
        public IList<AccountViewModel> Accounts { get; set; }
        public IList<AccountViewModel> CustomerAccounts { get; set; }
    }
}