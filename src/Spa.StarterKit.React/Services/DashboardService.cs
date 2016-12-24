using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using MPD.Core.Infrastructure.NetCore.Interfaces;
using MPD.Electio.SDK.NetCore.DataTypes.CarrierServiceDirectory.v1_1;
using MPD.Electio.SDK.NetCore.DataTypes.Consignments.v1_1;
using MPD.Electio.SDK.NetCore.Interfaces.Services;
using Spa.StarterKit.React.Services.Interfaces;
using Spa.StarterKit.React.ViewModels.Dashboard;
using MPD.Electio.SDK.NetCore.DataTypes.Consignments.v1_1.Enums;
using Spa.StarterKit.React.Extensions;
using MPD.Electio.SDK.NetCore.DataTypes.Profile.v1_1;

namespace Spa.StarterKit.React.Services
{
    public class DashboardService : IDashboardService
    {
        private readonly Spa.StarterKit.React.Services.Interfaces.IConsignmentService _consignments;
        private readonly IShippingLocationsService _shippingLocationsService;
        private readonly ILogger _logger;

        public DashboardService(Interfaces.IConsignmentService consignments,
                                   IShippingLocationsService shippingLocationsService,
                                   ILogger logger)
        {
            _consignments = consignments;
            _shippingLocationsService = shippingLocationsService;
            _logger = logger;
        }

        #region Combined

        public async Task<DashboardViewModel> GetDashboard(DateTime dateFrom, DateTime dateTo, string shippingLocationReference)
        {
            try
            {
                var getStatusSummaryTask = _consignments.GetConsignmentStatusSummaryAsync(dateFrom, dateTo);
                var getCarrierSummaryTask = _consignments.GetConsignmenCarrierSummaryAsync(dateFrom, dateTo);
                var getLateDataTask = _consignments.GetLateAndOnTimeConsignmentSummaryAsync(dateFrom, dateTo, shippingLocationReference);

                await Task.WhenAll(getStatusSummaryTask, getLateDataTask, getCarrierSummaryTask).ConfigureAwait(false);

                var statusSummary = await getStatusSummaryTask;
                var lateData = await getLateDataTask;
                var carrierSummary = await getCarrierSummaryTask;

                var getIssuesRadialsTask = GetIssuesRadialDataOperation(statusSummary);
                var getPreDespatchOverview = GetPreDespatchOverviewOperation(statusSummary);
                var getAllocatedCarriersChart = GetCarrierBarChartDataOperation(carrierSummary);
                var getAllocatedCarrierServices = GetCarrierServiceBarChartDataOperation(carrierSummary);
                var getPostDespatchRadials = GetPostDespatchRadialDataOperation(statusSummary, lateData);
                var getIssuesByCarrierChart = GetIssuesByCarrierStackedChartDataOperationAsync(carrierSummary);
                var getPostDespatchOverview = GetPostDespatchOverviewDataOperationAsync(statusSummary);
                var getConsignmentVolumeChart = GetAllocationByCarrierServiceByDateOperation(carrierSummary);
                var getAllocationByCarrierServiceChart = AllocationByCarrierServiceByDateOperation(carrierSummary);
                var getLateConsignmentsBarChart = GetLateConsignmentsBarChartDataOperationAsync(lateData);
                var getLateConsignmentsPieChart = GetLateConsignmentsPieChartDataOperationAsync(lateData);
                var getLateConsignmentsByCarrierStackedChart = GetLateConsignmentsStackedChartDataByCarrierOperationAsync(lateData);
                var getLateConsignmentsStackedChart = GetLateConsignmentsStackedChartDataOperationAsync(lateData);

                await Task.WhenAll(
                    getIssuesRadialsTask,
                    getPreDespatchOverview,
                    getAllocatedCarriersChart,
                    getAllocatedCarrierServices,
                    getPostDespatchRadials,
                    getIssuesByCarrierChart,
                    getPostDespatchOverview,
                    getConsignmentVolumeChart,
                    getAllocationByCarrierServiceChart,
                    getLateConsignmentsBarChart,
                    getLateConsignmentsPieChart,
                    getLateConsignmentsByCarrierStackedChart,
                    getLateConsignmentsStackedChart
                    ).ConfigureAwait(false);

                return new DashboardViewModel()
                {
                    IssuesRadialCharts = await getIssuesRadialsTask,
                    PreDespatchOverviewBarChart = await getPreDespatchOverview,
                    AllocatedCarriersBarChart = await getAllocatedCarriersChart,
                    AllocatedCarrierServicesBarChart = await getAllocatedCarrierServices,
                    PostDespatchRadialCharts = await getPostDespatchRadials,
                    IssuesByCarrierStackedChart = await getIssuesByCarrierChart,
                    PostDespatchOverviewBarChart = await getPostDespatchOverview,
                    LateConsignmentsBarChart = await getLateConsignmentsBarChart,
                    LateConsignmentsPieChart = await getLateConsignmentsPieChart,
                    LateConsignmentsByCarrierStackedChart = await getLateConsignmentsByCarrierStackedChart,
                    LateConsignmentsStackedChart = await getLateConsignmentsStackedChart,
                    AllocationByCarrierserviceByDate = await getConsignmentVolumeChart,
                    AllocationByCarrierService = await getAllocationByCarrierServiceChart
                };
            }
            catch (Exception ex)
            {
                _logger.Error(ex, ex.Message);
                return new DashboardViewModel();
            }
        }

        public async Task<DashboardViewModel> GetPreDespatchDashboard(DateTime dateFrom, DateTime dateTo, List<ShippingLocation> shippingLocationWhiteList, string shippingLocationReference)
        {
            try
            {
                var getStatusSummaryTask = _consignments.GetConsignmentStatusSummaryAsync(dateFrom, dateTo, shippingLocationReference);
                var getCarrierSummaryTask = _consignments.GetConsignmenCarrierSummaryAsync(dateFrom, dateTo, shippingLocationReference);

                await Task.WhenAll(getStatusSummaryTask, getCarrierSummaryTask).ConfigureAwait(false);

                var statusSummary = await getStatusSummaryTask;
                var carrierSummary = await getCarrierSummaryTask;

                var getIssuesRadialsTask = GetIssuesRadialDataOperation(statusSummary);
                var getPreDespatchOverview = GetPreDespatchOverviewOperation(statusSummary);
                var getAllocatedCarriersChart = GetCarrierBarChartDataOperation(carrierSummary);
                var getAllocatedCarrierServices = GetCarrierServiceBarChartDataOperation(carrierSummary);
                var getIssuesByCarrierChart = GetIssuesByCarrierStackedChartDataOperationAsync(carrierSummary);
                var getConsignmentVolumeChart = GetAllocationByCarrierServiceByDateOperation(carrierSummary);
                var getAllocationByCarrierServiceChart = AllocationByCarrierServiceByDateOperation(carrierSummary);

                await Task.WhenAll(
                    getIssuesRadialsTask,
                    getPreDespatchOverview,
                    getAllocatedCarriersChart,
                    getAllocatedCarrierServices,
                    getIssuesByCarrierChart,
                    getConsignmentVolumeChart,
                    getAllocationByCarrierServiceChart).ConfigureAwait(false);

                return new DashboardViewModel()
                {
                    IssuesRadialCharts = await getIssuesRadialsTask,
                    PreDespatchOverviewBarChart = await getPreDespatchOverview,
                    AllocatedCarriersBarChart = await getAllocatedCarriersChart,
                    AllocatedCarrierServicesBarChart = await getAllocatedCarrierServices,
                    IssuesByCarrierStackedChart = await getIssuesByCarrierChart,
                    AllocationByCarrierserviceByDate = await getConsignmentVolumeChart,
                    AllocationByCarrierService = await getAllocationByCarrierServiceChart,
                    AssignedShippingLocations = shippingLocationWhiteList,
                    SelectedShippingLocation = shippingLocationReference
                };
            }
            catch (Exception ex)
            {
                _logger.Error(ex, ex.Message);
                return new DashboardViewModel();
            }
        }

        public async Task<DashboardViewModel> GetPostDespatchDashboard(DateTime dateFrom, DateTime dateTo, List<ShippingLocation> shippingLocationWhiteList, string shippingLocationReference)
        {
            try
            {
                var getStatusSummaryTask = _consignments.GetConsignmentStatusSummaryAsync(dateFrom, dateTo, shippingLocationReference);
                var getCarrierSummaryTask = _consignments.GetConsignmenCarrierSummaryAsync(dateFrom, dateTo, shippingLocationReference);
                var getLateDataTask = _consignments.GetLateAndOnTimeConsignmentSummaryAsync(dateFrom, dateTo, shippingLocationReference);

                await Task.WhenAll(getStatusSummaryTask, getLateDataTask, getCarrierSummaryTask).ConfigureAwait(false);

                var statusSummary = await getStatusSummaryTask;
                var lateData = await getLateDataTask;
                var carrierSummary = await getCarrierSummaryTask;

                var getPostDespatchRadials = GetPostDespatchRadialDataOperation(statusSummary, lateData);
                var getIssuesByCarrierChart = GetIssuesByCarrierStackedChartDataOperationAsync(carrierSummary);
                var getPostDespatchOverview = GetPostDespatchOverviewDataOperationAsync(statusSummary);
                var getLateConsignmentsBarChart = GetLateConsignmentsBarChartDataOperationAsync(lateData);
                var getLateConsignmentsPieChart = GetLateConsignmentsPieChartDataOperationAsync(lateData);
                var getLateConsignmentsByCarrierStackedChart = GetLateConsignmentsStackedChartDataByCarrierOperationAsync(lateData);
                var getLateConsignmentsStackedChart = GetLateConsignmentsStackedChartDataOperationAsync(lateData);

                await Task.WhenAll(
                    getPostDespatchRadials,
                    getIssuesByCarrierChart,
                    getPostDespatchOverview,
                    getLateConsignmentsBarChart,
                    getLateConsignmentsPieChart,
                    getLateConsignmentsByCarrierStackedChart,
                    getLateConsignmentsStackedChart
                    ).ConfigureAwait(false);

                return new DashboardViewModel()
                {
                    PostDespatchRadialCharts = await getPostDespatchRadials,
                    IssuesByCarrierStackedChart = await getIssuesByCarrierChart,
                    PostDespatchOverviewBarChart = await getPostDespatchOverview,
                    LateConsignmentsBarChart = await getLateConsignmentsBarChart,
                    LateConsignmentsPieChart = await getLateConsignmentsPieChart,
                    LateConsignmentsByCarrierStackedChart = await getLateConsignmentsByCarrierStackedChart,
                    LateConsignmentsStackedChart = await getLateConsignmentsStackedChart,
                    AssignedShippingLocations = shippingLocationWhiteList,
                    SelectedShippingLocation = shippingLocationReference
                };
            }
            catch (Exception ex)
            {
                _logger.Error(ex, ex.Message);
                return new DashboardViewModel();
            }
        }

        public async Task<LateConsignmentsChartsViewModel> GetLateConsignmentsCharts(DateTime dateFrom, DateTime dateTo, string shippingLocationReference)
        {
            try
            {
                var getLateDataTask = _consignments.GetLateAndOnTimeConsignmentSummaryAsync(dateFrom, dateTo, shippingLocationReference);

                var lateData = await getLateDataTask;

                var getBarChartTask = GetLateConsignmentsBarChartDataOperationAsync(lateData);
                var getPieChartTask = GetLateConsignmentsPieChartDataOperationAsync(lateData);
                var getStackedChartByCarrierTask = GetLateConsignmentsStackedChartDataByCarrierOperationAsync(lateData);
                var getStackedChartData = GetLateConsignmentsStackedChartDataOperationAsync(lateData);

                await Task.WhenAll(getBarChartTask, getPieChartTask, getStackedChartByCarrierTask).ConfigureAwait(false);

                var barChart = await getBarChartTask;
                var pieChart = await getPieChartTask;
                var stackedChartByCarrier = await getStackedChartByCarrierTask;
                var stackedChart = await getStackedChartData;

                return new LateConsignmentsChartsViewModel()
                {
                    LateConsignmentsBarChart = barChart,
                    LateConsignmentsPieChart = pieChart,
                    LateConsignmentsByCarrierStackedChart = stackedChartByCarrier,
                    LateConsignmentsStackedChart = stackedChart
                };
            }
            catch (Exception ex)
            {
                _logger.Error(ex, ex.Message);
                return new LateConsignmentsChartsViewModel();
            }
        }

        #endregion Combined

        #region Pre-Despatch

        public async Task<IList<RadialItemViewModel>> GetIssuesRadialData(DateTime dateFrom, DateTime dateTo, string shippingLocationReference)
        {
            return await GetIssuesRadialDataOperation(dateFrom, dateTo, shippingLocationReference);
        }

        public async Task<IList<BarChartItemViewModel>> GetPreDespatchOverviewData(DateTime dateFrom, DateTime dateTo, string shippingLocationReference)
        {
            return await GetPreDespatchOverviewOperation(dateFrom, dateTo, shippingLocationReference);
        }

        public async Task<IList<BarChartItemViewModel>> GetCarrierBarChartData(DateTime dateFrom, DateTime dateTo, string shippingLocationReference)
        {
            return await GetCarrierBarChartDataOperation(dateFrom, dateTo, shippingLocationReference);
        }

        public async Task<IList<BarChartItemViewModel>> GetCarrierServiceBarChartData(DateTime dateFrom, DateTime dateTo, string shippingLocationReference)
        {
            return await GetCarrierServiceBarChartDataOperation(dateFrom, dateTo, shippingLocationReference);
        }

        public async Task<StackedChartViewModel> GetConsignmentVolumeByWeekData(DateTime dateFrom, DateTime dateTo, string shippingLocationReference)
        {
            return await GetConsignmentVolumeByWeekDataOperation(dateFrom, dateTo, shippingLocationReference);
        }

        #endregion Pre-Despatch

        #region Post-Despatch

        public async Task<IList<RadialItemViewModel>> GetPostDespatchRadialData(DateTime dateFrom, DateTime dateTo, string shippingLocationReference)
        {
            return await GetPostDespatchRadialDataOperation(dateFrom, dateTo, shippingLocationReference);
        }

        public async Task<StackedChartViewModel> GetIssuesByCarrierStackedChartData(DateTime dateFrom, DateTime dateTo, string shippingLocationReference)
        {
            return await GetIssuesByCarrierStackedChartDataOperationAsync(dateFrom, dateTo, shippingLocationReference);
        }

        public async Task<IList<BarChartItemViewModel>> GetPostDespatchOverviewData(DateTime dateFrom, DateTime dateTo, string shippingLocationReference)
        {
            return await GetPostDespatchOverviewDataOperationAsync(dateFrom, dateTo, shippingLocationReference);
        }

        public async Task<IList<BarChartItemViewModel>> GetLateConsignmentsBarChartData(DateTime dateFrom,
            DateTime dateTo, string shippingLocationReference)
        {
            return await GetLateConsignmentsBarChartDataOperationAsync(dateFrom, dateTo, shippingLocationReference);
        }

        public async Task<IList<BarChartItemViewModel>> GetLateConsignmentsPieChartData(DateTime dateFrom,
            DateTime dateTo, string shippingLocationReference)
        {
            return await GetLateConsignmentsPieChartDataOperationAsync(dateFrom, dateTo, shippingLocationReference);
        }

        public async Task<StackedChartViewModel> GetLateConsignmentsStackedChartData(DateTime dateFrom, DateTime dateTo, string shippingLocationReference)
        {
            return await GetLateConsignmentsStackedChartDataByCarrierOperationAsync(dateFrom, dateTo, shippingLocationReference);
        }

        #endregion Pre-Despatch

        #region Private Methods

        #region Pre-Despatch

        private async Task<IList<RadialItemViewModel>> GetIssuesRadialDataOperation(DateTime dateFrom, DateTime dateTo, string shippingLocationReference)
        {
            try
            {
                var statusSummary = await _consignments.GetConsignmentStatusSummaryAsync(dateFrom, dateTo, shippingLocationReference);
                return await GetIssuesRadialDataOperation(statusSummary);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, ex.Message);
                return null;
            }
        }

        private async Task<IList<RadialItemViewModel>> GetIssuesRadialDataOperation(StatusSummaryResponseModel statusSummary)
        {
            if (statusSummary == null)
            {
                return null;
            }

            try
            {
                return await Task.Run(() =>
                {
                    const int diameter = 120;
                    const string urlBase = "/Allocation/NotShipped/{0}";

                    var shippedDashboardRadialStates = new List<ConsignmentState>(new[]
                    {
                        ConsignmentState.Unallocated,
                        ConsignmentState.AllocationFailed,
                        ConsignmentState.ManifestFailed
                    });

                    var total =
                        statusSummary.Summary.Where(item => shippedDashboardRadialStates.Contains(item.Key))
                            .Sum(item => item.Value);

                    return shippedDashboardRadialStates.Select(ss => new RadialItemViewModel()
                    {
                        Label = ss.UnCamelCase(),
                        Diameter = diameter,
                        Numerator = statusSummary.Summary[ss],
                        Denominator = total > 0 ? total : 1,
                        ButtonText = "Resolve",
                        Url = string.Format(urlBase, ss.ToString()),
                        Severity = ss.UiSeverity().ToString().ToLowerInvariant()
                    }).ToList();
                }).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, ex.Message);
                return null;
            }
        }

        private async Task<IList<BarChartItemViewModel>> GetPreDespatchOverviewOperation(DateTime dateFrom, DateTime dateTo, string shippingLocationReference)
        {
            try
            {
                var getConsignmentStatusSummary = _consignments.GetConsignmentStatusSummaryAsync(dateFrom, dateTo, shippingLocationReference);
                var consignmentStatusSummary = await getConsignmentStatusSummary;
                return await GetPreDespatchOverviewOperation(consignmentStatusSummary);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, ex.Message);
                return null;
            }
        }

        private async Task<IList<BarChartItemViewModel>> GetPreDespatchOverviewOperation(StatusSummaryResponseModel statusSummary)
        {
            if (statusSummary == null)
            {
                return null;
            }

            try
            {
                return await Task.Run(() =>
                {
                    return statusSummary.Summary
                        .Where(s => s.Value > 0 && ConsignmentStates.UnShipped.Contains(s.Key))
                        .Select(
                            s =>
                                new BarChartItemViewModel(s.Key.UnCamelCase(), s.Value,
                                    $"/Allocation/NotShipped/{s.Key}"))
                        .ToList();
                }).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, ex.Message);
                return null;
            }
        }

        private async Task<IList<BarChartItemViewModel>> GetCarrierBarChartDataOperation(DateTime dateFrom, DateTime dateTo, string shippingLocationReference)
        {
            try
            {
                var getCarrierSummaryTask = _consignments.GetConsignmenCarrierSummaryAsync(dateFrom, dateTo, shippingLocationReference);

                await getCarrierSummaryTask;

                var carrierStatusSummary = await getCarrierSummaryTask;

                return await GetCarrierBarChartDataOperation(carrierStatusSummary);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, ex.Message);
                return null;
            }
        }

        private async Task<IList<BarChartItemViewModel>> GetCarrierBarChartDataOperation(CarrierStatusResponseModel carrierStatusSummary)
        {
            if (carrierStatusSummary == null)
            {
                return new List<BarChartItemViewModel>();
            }

            try
            {
                return await Task.Run(() =>
                {
                    var mpdCarrierReferences = carrierStatusSummary.Summary.Select(s => s.MpdCarrierReference).Distinct();

                    var carrierConsignments = mpdCarrierReferences.Select
                    (
                        mcr => new
                        {
                            MpdCarrierName = carrierStatusSummary.Summary.First(s => s.MpdCarrierReference == mcr).MpdCarrierName,
                            Consignments = carrierStatusSummary.Summary
                                                               .Where(s => s.MpdCarrierReference == mcr && (s.ConsignmentState == ConsignmentState.Allocated || s.ConsignmentState == ConsignmentState.Manifested))
                                                               .Sum(s => s.NumberOfConsignments)
                        }
                    );

                    return carrierConsignments
                        .Where(cc => cc.Consignments > 0)
                        .Select(cc => new BarChartItemViewModel(cc.MpdCarrierName, cc.Consignments, null))
                        .ToList();
                }).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, ex.Message);
                return null;
            }
        }

        private async Task<IList<BarChartItemViewModel>> GetCarrierServiceBarChartDataOperation(DateTime dateFrom, DateTime dateTo, string shippingLocationReference)
        {
            try
            {
                var carrierStatusTask = _consignments.GetConsignmenCarrierSummaryAsync(dateFrom, dateTo, shippingLocationReference);

                await carrierStatusTask;

                var carrierStatusResult = await carrierStatusTask;

                return await GetCarrierServiceBarChartDataOperation(carrierStatusResult);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, ex.Message);
                return null;
            }
        }

        private async Task<IList<BarChartItemViewModel>> GetCarrierServiceBarChartDataOperation(CarrierStatusResponseModel carrierStatusSummary)
        {
            if (carrierStatusSummary == null)
            {
                return new List<BarChartItemViewModel>();
            }

            try
            {
                return await Task.Run(() =>
                {
                    var mpdCarrierServiceReferences = carrierStatusSummary.Summary.Select(s => s.MpdCarrierServiceReference).Distinct();

                    var consignmentsByService = mpdCarrierServiceReferences.Select(mcsr => new
                    {
                        MpdCarrierServiceName = carrierStatusSummary.Summary.FirstOrDefault(s => s.MpdCarrierServiceReference == mcsr).MpdCarrierServiceName,
                        Consignments = carrierStatusSummary.Summary
                                                           .Where(s => s.MpdCarrierServiceReference == mcsr && (s.ConsignmentState == ConsignmentState.Allocated || s.ConsignmentState == ConsignmentState.Manifested))
                                                           .Sum(s => s.NumberOfConsignments)
                    }).ToList();

                    return consignmentsByService
                        .Where(d => d.Consignments > 0)
                        .Select(d => new BarChartItemViewModel(d.MpdCarrierServiceName, d.Consignments, null))
                        .ToList();
                }).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, ex.Message);
                return null;
            }
        }

        private async Task<StackedChartViewModel> GetConsignmentVolumeByWeekDataOperation(DateTime dateFrom, DateTime dateTo, string shippingLocationReference)
        {
            var carrierStatusTask = _consignments.GetConsignmenCarrierSummaryAsync(dateFrom, dateTo, shippingLocationReference);

            await carrierStatusTask;

            var carrierStatusResult = carrierStatusTask.Result;

            return await GetAllocationByCarrierServiceByDateOperation(carrierStatusResult);
        }

        private async Task<StackedChartViewModel> GetAllocationByCarrierServiceByDateOperation(CarrierStatusResponseModel carrierStatusSummary)
        {
            if (carrierStatusSummary == null)
            {
                return new StackedChartViewModel();
            }

            return await Task.Run(() =>
            {
                var stackedChart = new StackedChartViewModel() { ChartData = new List<Dictionary<string, object>>() };

                var carriersStatusByWeek = carrierStatusSummary.Summary.OrderBy(x => x.Created).GroupBy(x =>
                    CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(x.Created.UtcDateTime, CalendarWeekRule.FirstDay, DayOfWeek.Monday)
                    );

                foreach (var result in carriersStatusByWeek)
                {
                    var chartEntry = new Dictionary<string, object> { { "Week", result.Key } };

                    foreach (var carrier in result.GroupBy(x => x.MpdCarrierReference))
                    {
                        var carrierName = carrier.Key == null ? "Not allocated" : carrierStatusSummary.Summary.FirstOrDefault(css => css.MpdCarrierReference == carrier.Key).MpdCarrierName;
                        chartEntry.Add(carrierName, carrier.Sum(x => x.NumberOfConsignments));
                    }

                    stackedChart.ChartData.Add(chartEntry);
                }

                return stackedChart;
            }).ConfigureAwait(false);
        }

        private async Task<MixedChartViewModel> AllocationByCarrierServiceByDateOperation(CarrierStatusResponseModel carrierStatusSummary)
        {
            return await Task.Run(() =>
            {
                var chartResult = new MixedChartViewModel();
                if (carrierStatusSummary == null)
                {
                    return chartResult;
                }

                var carriersStatusByWeek = carrierStatusSummary.Summary.OrderBy(x => x.Created).GroupBy(x =>
                        CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(x.Created.UtcDateTime, CalendarWeekRule.FirstDay, DayOfWeek.Monday)
                        ).ToList();

                var weeks = carriersStatusByWeek.Select(x => x.Key).ToList();
                var carriers = carrierStatusSummary.Summary.GroupBy(x => x.MpdCarrierName).ToList().Distinct().Select(x => x.Key).ToList();//.Select(c => string.IsNullOrWhiteSpace(c.Key) ? "Not allocated" : c.Key);

                chartResult.Labels = weeks.Select(x => x.ToString()).ToList();

                foreach (var carrier in carriers)
                {
                    chartResult.Datasets.Add(new MixedChartDatasetViewModel()
                    {
                        Label = carrier,
                        Values = new List<double>()
                    });
                }

                foreach (var week in weeks)
                {
                    var weekData = carriersStatusByWeek
                                    .Where(x => x.Key == week)
                                    .Select(x => x.ToList()).FirstOrDefault()
                                    ;
                    
                    foreach (var carrier in carriers)
                    {
                        var dataset = chartResult.Datasets.FirstOrDefault(x => x.Label == carrier);
                        if (dataset != null)
                        {
                            var sum =
                                weekData.Where(x => x.MpdCarrierName == carrier).Sum(x => x.NumberOfConsignments);
                            dataset.Values.Add(sum);
                        }
                    }
                }

                return chartResult;
            });
            
        }

        #endregion Pre-Despatch

        #region Post-Despatch

        private async Task<IList<RadialItemViewModel>> GetPostDespatchRadialDataOperation(DateTime dateFrom,
            DateTime dateTo, string shippingLocationReference)
        {
            try
            {
                var getConsignmentStatusSummaryTask = _consignments.GetConsignmentStatusSummaryAsync(dateFrom, dateTo, shippingLocationReference);

                var getLateDataTask = _consignments.GetLateAndOnTimeConsignmentSummaryAsync(dateFrom, dateTo, shippingLocationReference);
                await Task.WhenAll(getConsignmentStatusSummaryTask, getLateDataTask).ConfigureAwait(false);

                var statusSummary = getConsignmentStatusSummaryTask.Result;
                var lateData = getLateDataTask.Result;
                return await GetPostDespatchRadialDataOperation(statusSummary, lateData);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, ex.Message);
                return null;
            }
        }

        private async Task<IList<RadialItemViewModel>> GetPostDespatchRadialDataOperation(StatusSummaryResponseModel statusSummary, LateConsignmentSummaryResponse lateConsignments)
        {
            if (statusSummary == null)
            {
                return new List<RadialItemViewModel>();
            }

            try
            {
                return await Task.Run(() =>
                {
                    const int diameter = 120;
                    const string urlBase = "/Allocation/Shipped/{0}";

                    var notShippedDashboardRadialStates = new List<ConsignmentState>(new[]
                    {
                        ConsignmentState.ActionRequired,
                        ConsignmentState.Missing,
                        ConsignmentState.Lost,
                        ConsignmentState.Damaged,
                        ConsignmentState.DeliveryFailed,
                        ConsignmentState.PartiallyDelivered
                    });

                    var total =
                        statusSummary.Summary.Where(item => notShippedDashboardRadialStates.Contains(item.Key))
                            .Sum(item => item.Value);

                    var result = notShippedDashboardRadialStates.Select(ss => new RadialItemViewModel()
                    {
                        Label = ss.UnCamelCase(),
                        Diameter = diameter,
                        Numerator = statusSummary.Summary[ss],
                        Denominator = total > 0 ? total : 1,
                        ButtonText = "View",
                        Url = string.Format(urlBase, ss.ToString()),
                        Severity = ss.UiSeverity().ToString().ToLowerInvariant()
                    }).ToList();

                    var totalLate = lateConsignments?.LateConsignments.Sum(x => x.NumberOfConsignments) ?? 0;

                    result.Add(new RadialItemViewModel()
                    {
                        Label = "Late",
                        Diameter = diameter,
                        Numerator = totalLate, // lateConsignments.TotalNumberOfLateConsignments,
                        Denominator = lateConsignments == null ? 1 :
                            totalLate == 0
                                ? 1
                                : totalLate,
                        ButtonText = "View",
                        Url = "/Allocation/Late",
                        Severity = "None",
                        ShowButton = true
                    });

                    return result;
                }).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, ex.Message);
                return null;
            }
        }

        private async Task<StackedChartViewModel> GetIssuesByCarrierStackedChartDataOperationAsync(DateTime dateFrom, DateTime dateTo, string shippingLocationReference)
        {
            try
            {
                var carrierSummaryTask = _consignments.GetConsignmenCarrierSummaryAsync(dateFrom, dateTo, shippingLocationReference);

                await carrierSummaryTask;

                var carrierSummary = carrierSummaryTask.Result;

                return await GetIssuesByCarrierStackedChartDataOperationAsync(carrierSummary);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, ex.Message);
                return null;
            }
        }

        private async Task<StackedChartViewModel> GetIssuesByCarrierStackedChartDataOperationAsync(CarrierStatusResponseModel carrierStatusSummary)
        {
            if (carrierStatusSummary == null)
            {
                return new StackedChartViewModel();
            }

            try
            {
                return await Task.Run(() =>
                {
                    var issues = new List<ConsignmentState>
                    {
                        ConsignmentState.ActionRequired,
                        ConsignmentState.Damaged,
                        ConsignmentState.Missing,
                        ConsignmentState.Lost,
                        ConsignmentState.DeliveryFailed,
                        ConsignmentState.PartiallyDelivered
                    };

                    var viewModel = new StackedChartViewModel { ChartData = new List<Dictionary<string, object>>() };

                    var mpdCarrierReferences = carrierStatusSummary.Summary.Select(css => css.MpdCarrierReference).Distinct();

                    foreach (var mpdCarrierReference in mpdCarrierReferences)
                    {
                        var addedIssue = false;
                        var dictionary = new Dictionary<string, object> { { "carrier", carrierStatusSummary.Summary.First(s => s.MpdCarrierReference == mpdCarrierReference).MpdCarrierName } };

                        foreach (
                            var carrierSummary in
                                carrierStatusSummary.Summary.Where(
                                    s => s.MpdCarrierReference == mpdCarrierReference && issues.Contains(s.ConsignmentState)))
                        {
                            addedIssue = true;
                            var stateDescription = carrierSummary.ConsignmentState.UnCamelCase();
                            if (dictionary.ContainsKey(stateDescription))
                            {
                                int currentValue;
                                var dictionaryItem = dictionary[stateDescription];
                                int.TryParse(dictionaryItem.ToString(), out currentValue);
                                dictionary[stateDescription] = currentValue + carrierSummary.NumberOfConsignments;
                            }
                            else
                            {
                                dictionary.Add(carrierSummary.ConsignmentState.UnCamelCase(),
                                carrierSummary.NumberOfConsignments);
                            }
                        }

                        if (addedIssue)
                        {
                            viewModel.ChartData.Add(dictionary);
                        }
                    }

                    return viewModel;
                }).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, ex.Message);
                return null;
            }
        }

        private async Task<IList<BarChartItemViewModel>> GetPostDespatchOverviewDataOperationAsync(DateTime dateFrom, DateTime dateTo, string shippingLocationReference)
        {
            try
            {
                var statusSummary = await _consignments.GetConsignmentStatusSummaryAsync(dateFrom, dateTo, shippingLocationReference);
                return await GetPostDespatchOverviewDataOperationAsync(statusSummary);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, ex.Message);
                return null;
            }
        }

        private async Task<IList<BarChartItemViewModel>> GetPostDespatchOverviewDataOperationAsync(StatusSummaryResponseModel statusSummary)
        {
            if (statusSummary == null)
            {
                return new List<BarChartItemViewModel>();
            }

            try
            {
                return await Task.Run(() =>
                {
                    const string urlBase = "/Allocation/Shipped/{0}";

                    var includedStates = ConsignmentStates.Shipped.Where(x => x != ConsignmentState.DeliveryFailedCardLeft).Distinct();

                    return includedStates
                            .Select(ss => new BarChartItemViewModel(ss.UnCamelCase(), statusSummary.Summary[ss], string.Format(urlBase, ss.ToString())))
                            .ToList();
                }).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, ex.Message);
                return null;
            }
        }

        private async Task<IList<BarChartItemViewModel>> GetLateConsignmentsBarChartDataOperationAsync(DateTime dateFrom, DateTime dateTo, string shippingLocationReference)
        {
            try
            {
                var lateData = await _consignments.GetLateAndOnTimeConsignmentSummaryAsync(dateFrom, dateTo, shippingLocationReference);
                return await GetLateConsignmentsBarChartDataOperationAsync(lateData);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, ex.Message);
                return null;
            }
        }

        private async Task<IList<BarChartItemViewModel>> GetLateConsignmentsBarChartDataOperationAsync(LateConsignmentSummaryResponse lateData)
        {
            if (lateData?.LateConsignments == null)
            {
                return new List<BarChartItemViewModel>();
            }

            try
            {
                return await Task.Run(() =>
                {
                    return new List<BarChartItemViewModel>(new[]
                    {
                        new BarChartItemViewModel("<1 day late", lateData.LateConsignments.Where(p => p.DaysLate == 0).Sum(p => p.NumberOfConsignments), null),
                        new BarChartItemViewModel("1 day late", lateData.LateConsignments.Where(p => p.DaysLate == 1).Sum(p => p.NumberOfConsignments), null),
                        new BarChartItemViewModel("2 days late", lateData.LateConsignments.Where(p => p.DaysLate == 2).Sum(p => p.NumberOfConsignments), null),
                        new BarChartItemViewModel("3-5 days late", lateData.LateConsignments.Where(p => p.DaysLate > 2 && p.DaysLate <= 5).Sum(p => p.NumberOfConsignments), null),
                        new BarChartItemViewModel(">5 days late", lateData.LateConsignments.Where(p => p.DaysLate > 5 ).Sum(p => p.NumberOfConsignments), null),
                    });
                }).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, ex.Message);
                return null;
            }
        }

        private async Task<IList<BarChartItemViewModel>> GetLateConsignmentsPieChartDataOperationAsync(DateTime dateFrom, DateTime dateTo, string shippingLocationReference)
        {
            try
            {
                var lateData = await _consignments.GetLateAndOnTimeConsignmentSummaryAsync(dateFrom, dateTo, shippingLocationReference);
                return await GetLateConsignmentsPieChartDataOperationAsync(lateData);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, ex.Message);
                return null;
            }
        }

        private async Task<IList<BarChartItemViewModel>> GetLateConsignmentsPieChartDataOperationAsync(LateConsignmentSummaryResponse lateData)
        {
            if (lateData?.LateConsignments == null || lateData.OnTimeConsignments == null)
            {
                return new List<BarChartItemViewModel>();
            }

            try
            {
                return await Task.Run(() =>
                {
                    return new List<BarChartItemViewModel>()
                    {
                        new BarChartItemViewModel("On time", lateData.OnTimeConsignments.Sum(p => p.NumberOfConsignments), null),
                        new BarChartItemViewModel("Carrier is late", lateData.LateConsignments.Sum(p => p.NumberOfConsignments), null),
                    };
                }).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, ex.Message);
                return null;
            }
        }

        private async Task<StackedChartViewModel> GetLateConsignmentsStackedChartDataByCarrierOperationAsync(DateTime dateFrom, DateTime dateTo, string shippingLocationReference)
        {
            try
            {
                var getLateDataTask = _consignments.GetLateAndOnTimeConsignmentSummaryAsync(dateFrom, dateTo, shippingLocationReference);

                await getLateDataTask;

                var lateData = await getLateDataTask;

                return await GetLateConsignmentsStackedChartDataByCarrierOperationAsync(lateData);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, ex.Message);
                return null;
            }
        }

        private async Task<StackedChartViewModel> GetLateConsignmentsStackedChartDataOperationAsync(LateConsignmentSummaryResponse lateData)
        {
            if (lateData?.LateConsignments == null)
            {
                return new StackedChartViewModel();
            }

            try
            {
                return await Task.Run(() =>
                {
                    var stackedModel = new StackedChartViewModel { ChartData = new List<Dictionary<string, object>>() };

                    stackedModel.ChartData.Add(new Dictionary<string, object>()
                    {
                        { "Late", "<1 day late"},
                        { "Carrier is late", lateData.LateConsignments.Where(x => x.DaysLate == 0).Sum(x => x.NumberOfConsignments)},
                        { "We are late", lateData.LateConsignmentsFromCustomerPerspective.Where(x => x.DaysLate == 0).Sum(x => x.NumberOfConsignments)}
                    });
                    stackedModel.ChartData.Add(new Dictionary<string, object>()
                    {
                        { "Late", "1 day late"},
                        { "Carrier is late", lateData.LateConsignments.Where(x => x.DaysLate == 1).Sum(x => x.NumberOfConsignments)},
                        { "We are late", lateData.LateConsignmentsFromCustomerPerspective.Where(x => x.DaysLate == 1).Sum(x => x.NumberOfConsignments)}
                    });
                    stackedModel.ChartData.Add(new Dictionary<string, object>()
                    {
                        { "Late", "2 days late"},
                        { "Carrier is late", lateData.LateConsignments.Where(x => x.DaysLate == 2).Sum(x => x.NumberOfConsignments)},
                        { "We are late", lateData.LateConsignmentsFromCustomerPerspective.Where(x => x.DaysLate == 2).Sum(x => x.NumberOfConsignments)}
                    });
                    stackedModel.ChartData.Add(new Dictionary<string, object>()
                    {
                        { "Late", "3-5 days late"},
                        { "Carrier is late", lateData.LateConsignments.Where(x => x.DaysLate >= 3 && x.DaysLate <= 5).Sum(x => x.NumberOfConsignments)},
                        { "We are late", lateData.LateConsignmentsFromCustomerPerspective.Where(x => x.DaysLate >= 3 && x.DaysLate <= 5).Sum(x => x.NumberOfConsignments)}
                    });
                    stackedModel.ChartData.Add(new Dictionary<string, object>()
                    {
                        { "Late", ">5 days late"},
                        { "Carrier is late", lateData.LateConsignments.Where(x => x.DaysLate > 5).Sum(x => x.NumberOfConsignments)},
                        { "We are late", lateData.LateConsignmentsFromCustomerPerspective.Where(x => x.DaysLate > 5).Sum(x => x.NumberOfConsignments)}
                    });

                    return stackedModel;
                }).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, ex.Message);
                return new StackedChartViewModel();
            }
        }

        private static List<Carrier> GetCarriersFromLateConsignmentSummary(LateConsignmentSummaryResponse lateConsignmentSummary)
        {
            var carriers = new List<Carrier>();

            foreach (var lc in lateConsignmentSummary.LateConsignments)
            {
                if (!carriers.Any(c => c.Reference == lc.CarrierReference))
                {
                    carriers.Add(new Carrier() { Reference = lc.CarrierReference, Name = lc.CarrierName });
                }
            }

            foreach (var lccp in lateConsignmentSummary.LateConsignmentsFromCustomerPerspective)
            {
                if (!carriers.Any(c => c.Reference == lccp.CarrierReference))
                {
                    carriers.Add(new Carrier() { Reference = lccp.CarrierReference, Name = lccp.CarrierName });
                }
            }

            return carriers;
        }

        private async Task<StackedChartViewModel> GetLateConsignmentsStackedChartDataByCarrierOperationAsync(LateConsignmentSummaryResponse lateData)
        {
            if (lateData?.LateConsignments == null)
            {
                return new StackedChartViewModel();
            }

            try
            {
                return await Task.Run(() =>
                {
                    var carriers = GetCarriersFromLateConsignmentSummary(lateData);
                    var stackedViewModel = new StackedChartViewModel() { ChartData = new List<Dictionary<string, object>>() };

                    foreach (var carrier in carriers.OrderBy(c => c.Name))
                    {
                        var lateConsignments =
                            lateData.LateConsignments.Where(
                                lc => "MPD_" + lc.CarrierReference == carrier.Reference || lc.CarrierReference == carrier.Reference).Sum(lc => lc.NumberOfConsignments);

                        var weAreLateConsignments = lateData.LateConsignmentsFromCustomerPerspective.Where(
                                lc => "MPD_" + lc.CarrierReference == carrier.Reference || lc.CarrierReference == carrier.Reference).Sum(lc => lc.NumberOfConsignments);

                        if (lateConsignments == 0 && weAreLateConsignments == 0)
                        {
                            continue;
                        }

                        stackedViewModel.ChartData.Add(new Dictionary<string, object>()
                        {
                            { "Carrier", carrier.Name},
                            { "Carrier is Late", lateConsignments},
                            { "We are late", weAreLateConsignments}
                        });
                    }

                    return stackedViewModel;
                }).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, ex.Message);
                return null;
            }
        }

        #endregion Post-Despatch

        #endregion Private Methods
    }
}
