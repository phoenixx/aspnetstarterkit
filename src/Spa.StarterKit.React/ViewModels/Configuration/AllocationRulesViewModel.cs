using System.Collections.Generic;
using Spa.StarterKit.React.Models;
using Spa.StarterKit.React.ViewModels.Allocation.Enums;
using Spa.StarterKit.React.ViewModels.Configuration.CarrierServiceGroups;

namespace Spa.StarterKit.React.ViewModels.Configuration
{
    public class AllocationRulesViewModel : SortableModel
    {
        public string SearchExpression { get; set; }
        public IList<CustomerCarrierServiceViewModel> CarrierServices { get; set; }
        public CarrierServiceType CarrierServiceType { get; set; }
    }
}