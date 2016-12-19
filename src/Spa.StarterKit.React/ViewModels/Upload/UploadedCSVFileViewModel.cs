using System;

namespace Spa.StarterKit.React.ViewModels.Upload
{
    public class UploadedCSVFileViewModel
    {
        public string FileRef { get; set; }
        public string FileName { get; set; }
        public string ErrorFileName { get; set; }
        public DateTime DateUploaded { get; set; }
    }
}
