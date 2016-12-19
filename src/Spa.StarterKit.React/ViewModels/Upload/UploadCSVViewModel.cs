
namespace Spa.StarterKit.React.ViewModels.Upload
{
    public class UploadCSVViewModel
    {
        public UploadCSVViewModel()
        {
            HasHeaderRow = true;
            IsItemLevelData = true;
            GroupPackagesIntoConsignments = false;
        }

        public bool HasHeaderRow { get; set; }
        public bool IsItemLevelData { get; set; }
        public bool GroupPackagesIntoConsignments { get; set; }
    }
}