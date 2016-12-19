
namespace Spa.StarterKit.React.ViewModels.Upload
{
    public class UploadedCSVSummaryViewModel
    {
        public bool IsItemLevelData { get; set; }
        public bool GroupPackagesIntoConsignments { get; set; }

        public string FileRef { get; set; }
        public string FileName { get; set; }
        public string ErrorFileName { get; set; }

        public int TotalLinesInFile { get; set; }
        public int ValidLinesInFile { get; set; }
        public int PackagesRead { get; set; }
        public int ConsignmentsFound { get; set; }
    }
}