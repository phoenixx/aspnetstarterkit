using System.ComponentModel;
using FluentValidation.Attributes;
using Spa.StarterKit.React.ViewModels.FluentValidators.ManualUpload;

namespace Spa.StarterKit.React.ViewModels.Allocation.ManualUpload
{
    [Validator(typeof(CustomsItemViewModelValidator))]
    public class CustomsItemViewModel
    {
        [DisplayName("Item description")]
        public string Description { get; set; }

        [DisplayName("Country of origin")]
        public string CountryRef { get; set; }

        [DisplayName("Harmonization code")]
        public string HarmonizationCode { get; set; }

        public decimal Value { get; set; }
        public string Currency {get; set; }
        public decimal Weight { get; set; }


        public int Quantity { get; set; }
    }
}
