using System.Collections.Generic;

namespace Spa.StarterKit.React.ViewModels.Dashboard
{
    public class LateConsignmentsChartsViewModel
    {
        public IList<BarChartItemViewModel> LateConsignmentsBarChart { get; set; }
        public IList<BarChartItemViewModel> LateConsignmentsPieChart { get; set; }
        public StackedChartViewModel LateConsignmentsStackedChart { get; set; }
        public StackedChartViewModel LateConsignmentsByCarrierStackedChart { get; set; }
    }
}