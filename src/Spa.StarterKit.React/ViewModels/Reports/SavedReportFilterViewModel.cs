using System.Runtime.Serialization;

namespace Spa.StarterKit.React.ViewModels.Reports
{
	[DataContract]
    public class SavedReportFilterViewModel
    {
        public SavedReportFilterViewModel()
        {
            Filters = new ReportFilterBaseViewModel();
        }

		[DataMember]
		public int Id { get; set; }

		[DataMember]
        public string Title { get; set; }

		[DataMember]
		public string Description { get; set; }

		[DataMember]
		public string Reference { get; set; }

		[DataMember]
		public ReportFilterBaseViewModel Filters { get; set; }
	}
}