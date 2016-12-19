using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FluentValidation.Attributes;
using Microsoft.AspNetCore.Mvc.Rendering;
using Spa.StarterKit.React.ViewModels.FluentValidators.Shared;

namespace Spa.StarterKit.React.ViewModels.Shared.Payment
{
    [Serializable]
    [Validator(typeof(CardDetailsValidator))]
    public class CardDetailsViewModel
    {
        public IList<CardTypeViewModel> CardTypes { get; set; }
        public IEnumerable<SelectListItem> ValidMonths { get; set; }
        public IEnumerable<SelectListItem> ValidFromYears { get; set; }
        public IEnumerable<SelectListItem> ValidExpiryYears { get; set; }

        public CardTypeViewModel CardType { get; set; }

        [Display(Name = "Credit Card Number")]
        public string CardNumber { get; set; }

        public string FromMonth { get; set; }

        public string FromYear { get; set; }

        public string ExpiresMonth { get; set; }

        public string ExpiresYear { get; set; }

        public string NameOnCard { get; set; }

        [Display(Name = "Card Security Code")]
        public string SecurityNumber { get; set; }
    }
}