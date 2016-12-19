
namespace Spa.StarterKit.React.ViewModels.Upload
{
    public class MapCSVFieldsViewModel
    {
        public string FileRef { get; set; }
        public string FileName { get; set; }
        public int TotalLinesInFile { get; set; }
        public ElectioFieldViewModel[] ElectioFields { get; set; }
        public string[] CSVFields { get; set; }
    }
}