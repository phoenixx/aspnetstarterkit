using System.Collections.Generic;
using System.Linq;
using MPD.Electio.SDK.NetCore.DataTypes.Common.v1_1;
using MPD.Electio.SDK.NetCore.Internal.DataTypes.ConfigurationReports.Enums;

namespace Spa.StarterKit.React.ViewModels.Configuration.CarrierServices
{
    public class MpdCarrierServiceConfigurationViewModel
    {
        public MpdCarrierService MpdCarrierService { get; set; }
        public List<ConfigurationReportViewModel> ConfigurationReports { get; set; }

        public bool IsReady {
            get
            {
                return
                    ConfigurationReports.SelectMany(x => x.ConfigurationReport.Messages).All(y => y.Status != MessageStatus.Error);
            }
        }
    }
}