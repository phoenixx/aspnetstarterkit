using System.Collections.Generic;
using Spa.StarterKit.React.Models;

namespace Spa.StarterKit.React.ViewModels.Configuration
{
    public class ShippingLocationsViewModel : SortableModel
    {
        public string SearchExpression { get; set; }
        public IList<ShippingLocationItemViewModel> ShippingLocations { get; set; }
    }
}
