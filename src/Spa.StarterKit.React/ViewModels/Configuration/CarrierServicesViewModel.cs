using System.Collections.Generic;
using Spa.StarterKit.React.Models;
using Spa.StarterKit.React.ViewModels.Configuration.CarrierServiceGroups;

namespace Spa.StarterKit.React.ViewModels.Configuration
{
    public class CarrierServicesViewModel : SortableModel
    {
        public string SearchExpression { get; set; }
        public IList<CarrierServiceViewModel> CarrierServices { get; set; }
        public int MaximumCarrierCount { get; set; }
        public IList<string> CurrentCarriers { get; set; }
    }
}