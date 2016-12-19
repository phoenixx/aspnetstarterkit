using System.Collections.Generic;
using Spa.StarterKit.React.ViewModels.Configuration.CarrierServiceGroups;

namespace Spa.StarterKit.React.ViewModels.Carrier
{
    public class CarrierViewModel
    {
        public CarrierViewModel()
        {
            CarrierServices = new List<CarrierServiceViewModel>();
        }

        public int Id { get; set; }
        public string Reference { get; set; }
        public string Name { get; set; }

        public IList<CarrierServiceViewModel> CarrierServices { get; set; }
    }
}