using System;
using Spa.StarterKit.React.Models;
using Spa.StarterKit.React.ViewModels.User;

namespace Spa.StarterKit.React.ViewModels.Shared.Payment
{
    [Serializable]
    public class PayPalBeginPaymentViewModel
    {
        public AccountViewModel Account { get; set; }
        public decimal Amount { get; set; }
        public string CurrencyIsoCode { get; set; }
        public string ReturnUrl { get; set; }
        public string CancelUrl { get; set; }
        public MerchantVerification VerificationParams { get; set; }
    }
}