using Spa.StarterKit.React.ViewModels.Shared.Payment;

namespace Spa.StarterKit.React.ViewModels.Payment
{
   public class PayPalStartResult
    {
        public string TransactionReference { get; set; }
        public string Message { get; set; }
        public bool Success { get; set; }
        public PayPalBeginPaymentViewModel PayPalBeginPaymentViewModel { get; set; }
    }
}