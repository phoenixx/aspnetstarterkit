using System.Collections.Generic;
using Spa.StarterKit.React.Models;
using Spa.StarterKit.React.ViewModels.Company;
using Spa.StarterKit.React.ViewModels.User;

namespace Spa.StarterKit.React.ViewModels.Customer
{
    public class CustomerUserAccountsViewModel : SortableModel
    {
        public CompanyViewModel Customer { get; set; }
        public string SearchExpression { get; set; }
        public IList<AccountViewModel> Accounts { get; set; }
    }
}