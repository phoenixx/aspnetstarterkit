using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Spa.StarterKit.React.ViewModels.Shared.Company
{
    public class AddressEditViewModel
    {
        public SelectList AvailableCountries { get; set; }

        public string Reference { get; set; }

        public string Company { get; set; }

        [Required]
        [DisplayName("Address line 1")]
        public string Line1 { get; set; }

        [DisplayName("Address line 2")]
        public string Line2 { get; set; }

        [DisplayName("Address line 3")]
        public string Line3 { get; set; }
        
        [Required]
        public string Town { get; set; }

        [Required]
        public string County { get; set; }

        [Required]
        [DisplayName("Postcode")]
        public string PostCode { get; set;}

        [Required]
        public string CountryIsoCode { get; set; }
    }
}