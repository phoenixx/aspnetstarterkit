using System;

namespace Spa.StarterKit.React.ViewModels.Shared.Payment
{
    /// <summary>
    /// This matches the field naming conventions for SagePay
    /// <see cref="http://www.sagepay.co.uk/support/12/36/direct-integration-3d-secure"/>
    /// </summary>
    [Serializable]
    public class MerchantVerificationViewModel
    {
        public MerchantVerificationViewModel(string merchantVerificationUrl, string paReq, string md, string termUrl, string orderReference, decimal paymentAmount, string mpdTransactionReference)
        {
            MerchantVerificationUrl = merchantVerificationUrl;
            PaReq = paReq;
            MD = md;
            TermUrl = termUrl;
            OrderReference = orderReference;
            PaymentAmount = paymentAmount;
            MpdTransactionReference = mpdTransactionReference;
        }

        public string MerchantVerificationUrl { get; set; }
        /// <summary>
        /// The request object for the 3ds check
        /// </summary>
        public string PaReq { get; set; }
        public string MD { get; set; }
        public string TermUrl { get; set; }
        public string InnerUrl { get; set; }
        public string OrderReference { get; set; }
        public string MpdTransactionReference { get; set; }
        /// <summary>
        /// The response object from the 3ds check
        /// </summary>
        public string PaRes { get; set; }

        public decimal PaymentAmount { get; set; }
        /// <summary>
        /// Optional parameter for use in sign up process to determine the step id
        /// </summary>
        public int? StepId { get; set; }
    }
}