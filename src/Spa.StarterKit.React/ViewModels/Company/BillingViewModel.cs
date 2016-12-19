using System.Collections.Generic;
using MPD.Electio.SDK.NetCore.Internal.DataTypes.Accounts;
using Spa.StarterKit.React.ViewModels.Billing;

namespace Spa.StarterKit.React.ViewModels.Company
{
    public class BillingViewModel
    {
        public PaymentModel PaymentModel { get; set; }
        public decimal? WalletFunds { get; set; }
        public decimal? OutstandingCharges { get; set; }
        public List<InvoiceViewModel> Invoices { get; set; }
        public CreditHistoryViewModel CreditHistory { get; set; }
    }
}