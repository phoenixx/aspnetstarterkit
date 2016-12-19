using System.Collections.Generic;

namespace Spa.StarterKit.React.ViewModels.Configuration
{
    public class CarrierServiceGroupsViewModel
    {
        public CarrierServiceGroupsViewModel()
        {
            CarrierServiceGroups = new List<CarrierServiceGroupViewModel>();
        }

        public IList<CarrierServiceGroupViewModel> CarrierServiceGroups { get; set; }
    }
}