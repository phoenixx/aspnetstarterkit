using System.Collections.Generic;

namespace Spa.StarterKit.React.ViewModels.InvoiceReconciliation
{
    public class FileUploadViewModel
    {
        public IList<string> AllowedFileTypes { get; set; }
        public int MaxFileSizeInMb { get; set; }
        public IList<string> FileUploadTypes { get; set; } 
    }
}