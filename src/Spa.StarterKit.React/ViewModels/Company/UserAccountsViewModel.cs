using System.Collections.Generic;
using Spa.StarterKit.React.Models;
using Spa.StarterKit.React.ViewModels.User;

namespace Spa.StarterKit.React.ViewModels.Company
{
    public class UserAccountsViewModel : SortableModel
    {
        public string SearchExpression { get; set; }
        public IList<AccountViewModel> Accounts { get; set; }
    }
}