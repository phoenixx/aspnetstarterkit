using System;

namespace Spa.StarterKit.React.ViewModels.Shared.Payment
{
    [Serializable]
    public class ChargeTypeViewModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public TransactionFeeViewModel TransactionFee { get; set; }
    }
}