using System.Collections.Generic;
using System.Linq;
using Spa.StarterKit.React.ViewModels.Configuration.CarrierServiceGroups;

namespace Spa.StarterKit.React.ViewModels.Shared.CarriersAndServices
{
    public abstract class CarrierServiceSelectionByCarriersViewModel
    {
        protected CarrierServiceSelectionByCarriersViewModel()
        {
            CarrierServices = new List<CarrierServiceViewModel>();
        }

        public IList<CarrierServiceViewModel> CarrierServices { get; set; }
        
        public bool IsEnabled
        {
            get { return CarrierServices.Any(x => x.IsEnabled); }
        }
    }
}