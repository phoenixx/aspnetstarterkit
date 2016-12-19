using System.ComponentModel;

namespace Spa.StarterKit.React.ViewModels.Billing.Enums
{
    public enum InvoiceStatus
    {
        [Description(@"PAID")]
        Pending,
        [Description(@"UNPAID")]
        Paid,
        [Description(@"CANCELLED")]
        Cancelled,
    }
}