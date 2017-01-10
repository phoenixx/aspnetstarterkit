using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using MPD.Electio.SDK.NetCore.DataTypes.Profile.v1_1;

namespace Spa.StarterKit.React.ViewModels.Dashboard
{
    public class DashboardViewModel
    {
        public SelectList ShippingLocations { get; set; }

        public List<ShippingLocation> AssignedShippingLocations { get; set; }

        public string SelectedShippingLocation { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
        

        #region Pre-Despatch

        public IList<RadialItemViewModel> IssuesRadialCharts { get; set; }
        public IList<BarChartItemViewModel> PreDespatchOverviewBarChart { get; set; }
        public IList<BarChartItemViewModel> AllocatedCarriersBarChart { get; set; }
        public IList<BarChartItemViewModel> AllocatedCarrierServicesBarChart { get; set; }

        #endregion Pre-Despatch

        #region Post-Despatch

        public IList<RadialItemViewModel> PostDespatchRadialCharts { get; set; }
        public StackedChartViewModel IssuesByCarrierStackedChart { get; set; }
        public IList<BarChartItemViewModel> PostDespatchOverviewBarChart { get; set; }
        public IList<BarChartItemViewModel> LateConsignmentsBarChart { get; set; }
        public IList<BarChartItemViewModel> LateConsignmentsPieChart { get; set; }
        public StackedChartViewModel LateConsignmentsStackedChart { get; set; }
        public StackedChartViewModel LateConsignmentsByCarrierStackedChart { get; set; }

        public MixedChartViewModel AllocationByCarrierService { get; set; }
        public StackedChartViewModel AllocationByCarrierserviceByDate { get; set; }

        #endregion Post-Despatch
    }
}
