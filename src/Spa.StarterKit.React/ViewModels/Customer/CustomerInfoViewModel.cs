using Spa.StarterKit.React.ViewModels.Shared.Company;
using Spa.StarterKit.React.ViewModels.Shared.Customer;

namespace Spa.StarterKit.React.ViewModels.Customer
{
    public class CustomerInfoViewModel
    {
        public CustomerInfoViewModel()
        {
            CompanyInfo = new BasicCompanyInfoViewModel();
            CarrierServices = new CustomerCarrierServicesViewModel();
            PermissionRestrictions = new PermissionRestrictionsViewModel();
        }

        public BasicCompanyInfoViewModel CompanyInfo { get; set; }
        public CustomerCarrierServicesViewModel CarrierServices { get; set; }
        public PermissionRestrictionsViewModel PermissionRestrictions { get; set; }
    }
}