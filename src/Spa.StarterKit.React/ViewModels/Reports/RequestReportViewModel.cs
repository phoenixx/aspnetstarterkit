using FluentValidation.Attributes;
using MPD.Electio.SDK.NetCore.DataTypes.Reports.v1_1;
using Spa.StarterKit.React.ViewModels.FluentValidators.Reports;

namespace Spa.StarterKit.React.ViewModels.Reports
{
    [Validator(typeof(RequestReportViewModelValidator))]
    public class RequestReportViewModel
    {
	    public RequestReportViewModel()
	    {
		    Filters = new ReportFilters();
	    }

		public string SavedReportFilterName { get; set; }

		public ReportFilters Filters { get; set; }
	}
}
