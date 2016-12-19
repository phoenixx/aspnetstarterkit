using Spa.StarterKit.React.ViewModels.Billing.Enums;

namespace Spa.StarterKit.React.ViewModels.Billing
{
    public class AccountFundViewModel
    {
        //public IList<AccountFundLedgerItemViewModel> LedgerItems { get; set; }
        public AccountFundType AccountFundType { get; set; }
        public decimal Balance { get; set; }
    }
}