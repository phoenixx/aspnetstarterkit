using System;
using Spa.StarterKit.React.ViewModels.Shared.Customer;

namespace Spa.StarterKit.React.ViewModels.Customer
{
    public class EditCustomerCarrierServicesViewModel
    {
        public EditCustomerCarrierServicesViewModel()
        {
            CarrierServices =  new CustomerCarrierServicesViewModel();
        }

        public Guid CompanyReference { get; set; }
        public string Name { get; set; }
        public CustomerCarrierServicesViewModel CarrierServices { get; set; }
    }
}