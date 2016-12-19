using System;
using Spa.StarterKit.React.ViewModels.Shared.CarriersAndServices;

namespace Spa.StarterKit.React.ViewModels.Company
{
    public class CarrierServiceSetViewModel : CarrierServiceSelectionByCarriersViewModel
    {
        public Guid CompanyReference { get; set; }
        public Guid Ref { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}