using Spa.StarterKit.React.ViewModels.Shared.Company;
using Spa.StarterKit.React.ViewModels.Shared.Payment;

namespace Spa.StarterKit.React.ViewModels.Company
{
    public class TopUpFundsPaymentViewModel
    {
        public string TransactionReference { get; set; }
        public decimal TopUpAmount { get; set; }
        public CardDetailsViewModel CardDetails { get; set; }
        public AddressEditViewModel Address { get; set; }
        public AddressEditViewModel BillingAddress { get; set; }
    }
}