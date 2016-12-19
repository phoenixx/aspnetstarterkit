using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MPD.Electio.SDK.NetCore.DataTypes.Profile.v1_1;
using Spa.StarterKit.React.ViewModels.Dashboard;

namespace Spa.StarterKit.React.Services.Interfaces
{
    public interface IDashboardService
    {
        #region Combined

        Task<DashboardViewModel> GetDashboard(DateTime dateFrom, DateTime dateTo, string shippingLocationReference);
        Task<LateConsignmentsChartsViewModel> GetLateConsignmentsCharts(DateTime dateFrom, DateTime dateTo, string shippingLocationReference);

        #endregion

        #region Pre-Despatch

        Task<IList<RadialItemViewModel>> GetIssuesRadialData(DateTime dateFrom, DateTime dateTo, string shippingLocationReference);
        Task<IList<BarChartItemViewModel>> GetPreDespatchOverviewData(DateTime dateFrom, DateTime dateTo, string shippingLocationReference);
        Task<IList<BarChartItemViewModel>> GetCarrierBarChartData(DateTime dateFrom, DateTime dateTo, string shippingLocationReference);
        Task<IList<BarChartItemViewModel>> GetCarrierServiceBarChartData(DateTime dateFrom, DateTime dateTo, string shippingLocationReference);
        Task<StackedChartViewModel> GetConsignmentVolumeByWeekData(DateTime dateFrom, DateTime dateTo, string shippingLocationReference);
        Task<DashboardViewModel> GetPreDespatchDashboard(DateTime dateFrom, DateTime dateTo, List<ShippingLocation> shippingLocationWhiteList, string shippingLocationReference);

        #endregion Pre-Despatch

        #region Post-Despatch

        Task<IList<RadialItemViewModel>> GetPostDespatchRadialData(DateTime dateFrom, DateTime dateTo, string shippingLocationReference);
        Task<StackedChartViewModel> GetIssuesByCarrierStackedChartData(DateTime dateFrom, DateTime dateTo, string shippingLocationReference);
        Task<IList<BarChartItemViewModel>> GetPostDespatchOverviewData(DateTime dateFrom, DateTime dateTo, string shippingLocationReference);
        Task<IList<BarChartItemViewModel>> GetLateConsignmentsBarChartData(DateTime dateFrom, DateTime dateTo, string shippingLocationReference);
        Task<IList<BarChartItemViewModel>> GetLateConsignmentsPieChartData(DateTime dateFrom, DateTime dateTo, string shippingLocationReference);
        Task<StackedChartViewModel> GetLateConsignmentsStackedChartData(DateTime dateFrom, DateTime dateTo, string shippingLocationReference);
        Task<DashboardViewModel> GetPostDespatchDashboard(DateTime dateFrom, DateTime dateTo, List<ShippingLocation> shippingLocationWhiteList, string shippingLocationReference);

        #endregion Post-Despatch
    }
}