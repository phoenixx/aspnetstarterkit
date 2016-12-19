using System;
using Spa.StarterKit.React.ViewModels.Shared.Company;
using Spa.StarterKit.React.ViewModels.Shared.Payment;
using Spa.StarterKit.React.ViewModels.Shared.SignUp;

namespace Spa.StarterKit.React.ViewModels.SignUp
{
    public class SignUpViewModel : WizardModel
    {
        public SignUpViewModel()
        {
            Company = new CompanyEditViewModel();
            Account = new AccountSignUpViewModel();
        }

        public CompanyEditViewModel Company { get; set; }
        public AccountSignUpViewModel Account { get; set; }
        public Guid SubscriptionReference { get; set; }
        public string CancelUrl { get; set; }
        public string ReturnUrl { get; set; }
        public CardDetailsViewModel CardDetails { get; set; }
        public AddressEditViewModel CardDetailsAddress { get; set; }
    }
}