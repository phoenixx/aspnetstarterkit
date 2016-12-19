using System.Collections.Generic;
using Spa.StarterKit.React.ViewModels.AddressLookup;

namespace Spa.StarterKit.React.ViewModels.Configuration.Zones
{
    public class EditZoneViewModel
    {
        public ZoneViewModel Zone { get; set; }
        public List<CountryViewModel> Countries { get; set; }

        public EditZoneViewModel(ZoneViewModel zone, List<CountryViewModel> countries)
        {
            Zone = zone;
            Countries = countries;
        }
    }
}