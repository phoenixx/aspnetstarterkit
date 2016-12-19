using System;

namespace Spa.StarterKit.React.ViewModels.Company
{
    public class CreditHistoryItemViewModel
    {
        public DateTime Date { get; set; }
        public decimal Balance { get; set; }
        public decimal? PaymentReceived { get; set; }
        public decimal Outstanding { get; set; }
        public decimal DueNow { get; set; }
        public bool IsFuture { get; set; }
        public bool IsCurrent { get; set; }
    }
}