using System.ComponentModel;

namespace Spa.StarterKit.React.ViewModels.Billing.Enums
{
    public enum DocumentType
    {
        [Description(@"Invoice")]
        Invoice = 1,
        [Description(@"Credit_Note")]
        CreditNote = 2
    }
}