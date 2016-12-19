using System.Collections.Generic;
using System.Linq;
using MPD.Electio.SDK.NetCore.DataTypes.Reports.v1_1;
using MPD.Electio.SDK.NetCore.DataTypes.Reports.v1_1.Enums;

namespace Spa.StarterKit.React.ViewModels.Reports
{
    public class DownloadReportViewModel
    {
        private readonly List<ReportContract> _reports;

        public DownloadReportViewModel(List<ReportContract> reports)
        {
            _reports = reports;
        }

        // TODO: The ReportsProcessing List always appears to be emtpy.  In the Reports Service solution ReportStatus.Processing is only referenced once, in a test.

        public List<ReportContract> ReportsProcessing
        {
            get
            {
                return _reports.Where(r => r.Status == ReportStatus.Processing)
                              .OrderByDescending(r => r.DateRequested)
                              .ToList();
            }
        }

        public List<ReportContract> ReportsGenerated
        {
            get
            {
                return _reports.Where(r => r.Status == ReportStatus.Generated)
                              .OrderByDescending(r => r.DateRequested)
                              .ToList();
            }
        }

        public List<ReportContract> ReportsRequested
        {
            get
            {
                return _reports.Where(r => r.Status == ReportStatus.Requested)
                              .OrderByDescending(r => r.DateRequested)
                              .ToList();
            }
        }
    }
}
