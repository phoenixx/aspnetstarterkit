using System;
using Spa.StarterKit.React.ViewModels.Billing.Enums;

namespace Spa.StarterKit.React.ViewModels.Billing
{
    public class AccountFundLedgerItemViewModel
    {
        public DateTime TransactionDate { get; set; }
        public decimal Amount { get; set; }
        public AccountFundLedgerItemType Type { get; set; }
        public string Description { get; set; }
    }
}