using System;
using Spa.StarterKit.React.ViewModels.Shared.Company;
using Spa.StarterKit.React.ViewModels.Shared.Payment;

namespace Spa.StarterKit.React.ViewModels.SignUp
{
    public class SignupPaymentViewModel
    {
        public SignupPaymentViewModel()
        {
            Address = new AddressEditViewModel();
            CompanyBillingAddress = new AddressEditViewModel();
            CardDetails = new CardDetailsViewModel();
        }

        public AddressEditViewModel Address { get; set; }
        public AddressEditViewModel CompanyBillingAddress { get; set; }
        public CardDetailsViewModel CardDetails { get; set; }
        public Guid SubscriptionReference { get; set; }
        public string SubscriptionName { get; set; }
        public decimal? AmountPayable { get; set; }
        public int StepId { get; set; }
        public bool HasFaulted { get; set; }
    }
}