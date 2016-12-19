using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using Spa.StarterKit.React.ViewModels.Shared.Company;
using Spa.StarterKit.React.ViewModels.Shared.Payment;

namespace Spa.StarterKit.React.ViewModels.Company
{
    public class PayChargesViewModel
    {
        [DisplayName(@"Card Type")]
        public CardTypeViewModel CardType { get; set; }
        [DisplayName(@"Card Number")]
        public string CardNumber { get; set; }
        [DisplayName(@"Valid From Month")]
        public string ValidFromMonth { get; set; }
        [DisplayName(@"Valid From Year")]
        public string ValidFromYear { get; set; }
        [DisplayName(@"Valid To Month")]
        public string ValidToMonth { get; set; }
        [DisplayName(@"Valid To Year")]
        public string ValidToYear { get; set; }
        [DisplayName(@"Name on card")]
        public string NameOnCard { get; set; }
        [DisplayName(@"Security Number")]
        public string SecurityNumber { get; set; }

        public AddressEditViewModel Address { get; set; }

        public IEnumerable<SelectListItem> Months { get; set; }
        public IEnumerable<SelectListItem> FromYears { get; set; }
        public IEnumerable<SelectListItem> ToYears { get; set; }
        public IEnumerable<SelectListItem> CardTypes { get; set; }
    }
}
