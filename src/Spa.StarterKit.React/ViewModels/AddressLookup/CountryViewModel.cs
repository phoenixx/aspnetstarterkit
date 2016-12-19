namespace Spa.StarterKit.React.ViewModels.AddressLookup
{
    public class CountryViewModel
    {
        //public string CultureCode { get; set; }
        //public bool HasPostcodes { get; set; }
        public string Name { get; set; }
        //public int NumericIsoCode { get; set; }
        //public string PostCodeFormatRegExPattern { get; set; }
        //public string Reference { get; set; }
        //public string ThreeLetterIsoCode { get; set; }
        public string TwoLetterIsoCode { get; set; }

        public bool PostCodeRequired { get; set; } = true;
    }
}
