using System;
using Spa.StarterKit.React.ViewModels.Configuration.ShippingRules;

namespace Spa.StarterKit.React.ViewModels.Configuration
{
    public class ViewEditCarrierServiceProfileViewModel
    {
        public ViewEditCarrierServiceProfileViewModel()
        {
            ShippingRules = new ShippingRulesViewModel();
        }

        public Guid CompanyReference { get; set; }
        public string Reference { get; set; }
        public string CarrierName { get; set; }
        public string CarrierServiceName { get; set; }
        public string CarrierServiceReference { get; set; }
        public string Description { get; set; }

        public ShippingRulesViewModel ShippingRules { get; set; }
    }
}