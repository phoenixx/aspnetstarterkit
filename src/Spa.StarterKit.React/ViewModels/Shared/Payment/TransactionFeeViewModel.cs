using System;

namespace Spa.StarterKit.React.ViewModels.Shared.Payment
{
    [Serializable]
    public class TransactionFeeViewModel
    {
        public string PaymentMethod { get; set; }
        public string Description { get; set; }
        public decimal Percentage { get; set; }
        public decimal MinimumAmount { get; set; }
    }
}