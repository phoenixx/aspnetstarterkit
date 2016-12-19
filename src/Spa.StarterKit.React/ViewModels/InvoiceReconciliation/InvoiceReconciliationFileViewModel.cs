using System;

namespace Spa.StarterKit.React.ViewModels.InvoiceReconciliation
{
    public class InvoiceReconciliationFileViewModel
    {
        public string Description { get; set; }
        public string Filename { get; set; }
        public string FileExtension { get; set; }
        public string Container { get; set; }
        public Guid Reference { get; set; }
    }
}