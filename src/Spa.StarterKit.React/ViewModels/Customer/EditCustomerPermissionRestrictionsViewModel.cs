using System;
using Spa.StarterKit.React.ViewModels.Shared.Company;

namespace Spa.StarterKit.React.ViewModels.Customer
{
    public class EditCustomerPermissionRestrictionsViewModel
    {
        public EditCustomerPermissionRestrictionsViewModel()
        {
            PermissionRestrictions = new PermissionRestrictionsViewModel();
        }

        public Guid CompanyReference { get; set; }
        public string Name { get; set; }
        public PermissionRestrictionsViewModel PermissionRestrictions { get; set; }
    }
}