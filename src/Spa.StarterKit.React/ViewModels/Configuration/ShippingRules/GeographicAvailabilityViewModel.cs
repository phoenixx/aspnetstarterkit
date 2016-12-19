using System.Collections.Generic;
using MPD.Electio.SDK.NetCore.DataTypes.Common.v1_1;
using Spa.StarterKit.React.ViewModels.AddressLookup;
using Spa.StarterKit.React.ViewModels.Shared.Address;

namespace Spa.StarterKit.React.ViewModels.Configuration.ShippingRules
{
    public class GeographicAvailabilityViewModel
    {
        public GeographicAvailabilityViewModel()
        {
            RestrictedUkPostCodes = new List<UkPostcodeViewModel>();
            RestrictedCountries = new List<Country>();
        }

        public IList<CountryViewModel> AvailableCountries { get; set; } 

        public IList<UkPostcodeViewModel> RestrictedUkPostCodes { get; set; }
        public IList<Country> RestrictedCountries { get; set; }
    }
}