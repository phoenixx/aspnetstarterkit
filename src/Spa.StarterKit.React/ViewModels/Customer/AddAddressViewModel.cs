using System.Collections.Generic;
using Spa.StarterKit.React.ViewModels.AddressLookup;

namespace Spa.StarterKit.React.ViewModels.Customer
{
	public class AddAddressViewModel
	{
        public int? Id { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string Town { get; set; }
        public string CountyOrState { get; set; }
        public string Postcode { get; set; }
        public string CountryIsoCode { get; set; }

        public List<CountryViewModel> Countries { get; set; }
	}
}
