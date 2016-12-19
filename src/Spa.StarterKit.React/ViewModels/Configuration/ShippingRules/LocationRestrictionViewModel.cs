
namespace Spa.StarterKit.React.ViewModels.Configuration.ShippingRules
{
    public class LocationRestrictionViewModel
    {
        public int ServiceProfileId { get; set; }
        public int LocationRestrictionId { get; set; }
        public string CountryIsoCode { get; set; }

        public string PostcodeArea { get; set; }
        public string PostcodeDistrict { get; set; }
        public string PostcodeSector { get; set; }
        public string PostcodeUnit { get; set; }

        public string IntCounty { get; set; }
        public string IntPostcode { get; set; }
        public string IntTown { get; set; }
    }
}
