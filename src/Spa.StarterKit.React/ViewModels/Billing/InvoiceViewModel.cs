using System;
using Spa.StarterKit.React.ViewModels.Billing.Enums;

namespace Spa.StarterKit.React.ViewModels.Billing
{
    public class InvoiceViewModel
    {
        public string DocumentReference { get; set; }
        public DocumentType DocumentType { get; set; }
        public ChargeType ChargeType { get; set; }
        public DateTime DocumentDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? PaidDate { get; set; }
        public decimal Amount { get; set; }
        public InvoiceStatus Status { get; set; }
    }
}