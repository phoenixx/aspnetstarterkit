using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MPD.Electio.SDK.NetCore.DataTypes.Consignments.v1_1;
using MPD.Electio.SDK.NetCore.DataTypes.Consignments.v1_1.Enums;
using Spa.StarterKit.React.Extensions;
using Spa.StarterKit.React.Services.Interfaces;
using Spa.StarterKit.React.Utilities;
using Spa.StarterKit.React.ViewModels.Allocation;
using Spa.StarterKit.React.ViewModels.Allocation.Enums;
using Spa.StarterKit.React.ViewModels.Allocation.ManualUpload;
using Spa.StarterKit.React.ViewModels.Configuration.CarrierServiceGroups;
using Spa.StarterKit.React.ViewModels.Dashboard;

namespace Spa.StarterKit.React.Controllers.Consignments
{
    public class ConsignmentsController : Controller
    {
        private readonly IConsignmentService _consignmentService;
        private readonly IShippingLocationService _shippingLocationService;
        private readonly int _daysToStart = -30;// (0 - Constants.Consignments.DaysData);

        public ConsignmentsController(IConsignmentService consignmentService, IShippingLocationService shippingLocationService)
        {
            _consignmentService = consignmentService;
            _shippingLocationService = shippingLocationService;
        }

        [Route("consignments/notshipped")]
        public async Task<IActionResult> NotShipped(int skip = 0, int take = 10)
        {
            return await Consignments(ConsignmentStateType.NotShipped, null, skip, take);
        }

        [Route("consignments/notshipped/{state}")]
        public async Task<IActionResult> NotShippedByState(ConsignmentState state, int skip = 0, int take = 10)
        {
            return await Consignments(ConsignmentStateType.NotShipped, state, skip, take);
        }

        [Route("consignments/shipped/{state}")]
        public async Task<IActionResult> ShippedByState(ConsignmentState state, int skip = 0, int take = 10)
        {
            return await Consignments(ConsignmentStateType.Shipped, state, skip, take);
        }

        [Route("consignments/shipped")]
        public async Task<IActionResult> Shipped(int skip = 0, int take = 10)
        {
            return await Consignments(ConsignmentStateType.Shipped, null, skip, take);
        }

        [Route("consignments/stateheaders")]
        public async Task<IActionResult> GetRadials(ConsignmentStateType type)
        {
            var radials = await GetConsignmentRadials(type);
            return Json(radials);
        }

        private async Task<IActionResult> Consignments(ConsignmentStateType stateType, ConsignmentState? state,
            int skip = 0, int take = 10)
        {
            var statusDescription = state == null ? stateType.UnCamelCase() : state.UnCamelCase();
            //note, need to return as part of model...

            var search = new ConsignmentSearchTerms()
            {
                StateAttribute = stateType.ToString().ToLowerInvariant(),
                StartFrom = DateTime.Now.AddDays(_daysToStart),
                EndAt = DateTime.Today.AddDays(1),
                PageSize = take,
                StartPage = skip / take,
                State = state.HasValue ? state.ToString() : null
            };

            var getConsignmentsTask = _consignmentService.GetPagedConsignments(search);
            var getShippingLocationsTask = _shippingLocationService.GetAssignedShippingLocations();
            //carrier services (for filtering)
            //get carrier service groups (for filtering)

            return await Task.WhenAll(getConsignmentsTask, getShippingLocationsTask).ContinueWith(response =>
            {
                var getConsignmentsResult = getConsignmentsTask.Result;
                var shippingLocations = getShippingLocationsTask.Result;

                var consignments = getConsignmentsResult != null
                    ? getConsignmentsResult.ElectioConsignments
                    : new List<ConsignmentDetailViewModel>();

                var totalCount = getConsignmentsResult?.TotalMatchingCount ?? 0;
                var relevantStates = stateType == ConsignmentStateType.Shipped
                    ? ConsignmentStates.Shipped
                    : ConsignmentStates.UnShipped;

                var viewModel = new ConsignmentsViewModel()
                {
                    Consignments = consignments.ToList(),
                    TotalRecords = totalCount,
                    PageSize = take,
                    ConsignmentState = state,
                    ConsignmentSources = EnumHelper.EnumToKeyValuePairDescriptions<ConsignmentSource>(),
                    ShippingLocations = shippingLocations,
                    ConsignmentStateHeaders = new List<RadialItemViewModel>(0),
                    CustomerCarrierServices = new List<CarrierServiceViewModel>(0), //todo
                    ConsignmentStateType = stateType,
                    StateFilters = new List<ConsignmentStateFilter>(0), //todo
                    CarrierServiceGroups = new List<ServiceGroupViewModel>(0) //todo

                };

                return Json(viewModel);
            });
        }

        private async Task<IList<RadialItemViewModel>> GetConsignmentRadials(ConsignmentStateType stateType)
        {
            var relevantStates = stateType == ConsignmentStateType.Shipped
                ? ConsignmentStates.Shipped
                : ConsignmentStates.UnShipped;

            const string urlBase = "/{0}/{1}";

            var startDate = DateTime.Now.AddDays(_daysToStart);
            var endDate = DateTime.Now.AddDays(1);
            var stats = await _consignmentService.GetConsignmentStatusSummaryAsync(startDate, endDate);
            if (stats == null)
            {
                return new List<RadialItemViewModel>(0);
            }

            var statuses = stats.Summary.Where(s => relevantStates.Contains(s.Key)).ToList();

            var total = statuses.Sum(s => s.Value);

            var result =
                statuses.Select(consignmentState => SetRadialUiGroupings(consignmentState.Key, new RadialItemViewModel()
                {
                    ButtonText = consignmentState.Key.UnCamelCase(),
                    Denominator = total,
                    Diameter = 100,
                    Label = consignmentState.Key.UnCamelCase(),
                    Numerator = consignmentState.Value,
                    Url = string.Format(urlBase, stateType.ToString().ToLower(), consignmentState.Key.ToString().ToLower()),
                    Severity = consignmentState.Key.UiSeverity().ToString().ToLower(),
                    ShowButton = false
                })).ToList();

            result.Add(new RadialItemViewModel()
            {
                ButtonText = stateType.UnCamelCase(),
                Denominator = total,
                Diameter = 100,
                Label = stateType.UnCamelCase(),
                Numerator = total,
                Url = $"/{stateType.ToString().ToLower()}",
                Severity = "total",
                ShowButton = false,
                UiGroup = 4,
                UiPositionInGroup = 0
            });

            result = result.OrderBy(r => r.UiGroup).ThenBy(r => r.UiPositionInGroup).ToList();

            return result;

        }

        private static RadialItemViewModel SetRadialUiGroupings(ConsignmentState state, RadialItemViewModel radial)
        {
            // ReSharper disable once SwitchStatementMissingSomeCases
            switch (state)
            {
                case ConsignmentState.AtDropOffPoint:
                    radial.UiGroup = 1;
                    radial.UiPositionInGroup = 1;
                    break;
                case ConsignmentState.Collected:
                    radial.UiGroup = 1;
                    radial.UiPositionInGroup = 2;
                    break;
                case ConsignmentState.AtCollectionPoint:
                    radial.UiGroup = 1;
                    radial.UiPositionInGroup = 3;
                    break;
                case ConsignmentState.CollectionFailed:
                    radial.UiGroup = 1;
                    radial.UiPositionInGroup = 4;
                    break;
                case ConsignmentState.InTransit:
                    radial.UiGroup = 2;
                    radial.UiPositionInGroup = 1;
                    break;
                case ConsignmentState.InTransitWaiting:
                    radial.UiGroup = 2;
                    radial.UiPositionInGroup = 2;
                    break;
                case ConsignmentState.OutForDelivery:
                    radial.UiGroup = 2;
                    radial.UiPositionInGroup = 3;
                    break;
                case ConsignmentState.Delayed:
                    radial.UiGroup = 2;
                    radial.UiPositionInGroup = 4;
                    break;
                case ConsignmentState.ActionRequired:
                    radial.UiGroup = 2;
                    radial.UiPositionInGroup = 5;
                    break;
                case ConsignmentState.Missing:
                    radial.UiGroup = 2;
                    radial.UiPositionInGroup = 6;
                    break;
                case ConsignmentState.Lost:
                    radial.UiGroup = 2;
                    radial.UiPositionInGroup = 7;
                    break;
                case ConsignmentState.Damaged:
                    radial.UiGroup = 2;
                    radial.UiPositionInGroup = 8;
                    break;
                case ConsignmentState.Delivered:
                    radial.UiGroup = 3;
                    radial.UiPositionInGroup = 1;
                    break;
                case ConsignmentState.DeliveryFailedCardLeft:
                    radial.UiGroup = 3;
                    radial.UiPositionInGroup = 2;
                    break;
                case ConsignmentState.PartiallyDelivered:
                    radial.UiGroup = 3;
                    radial.UiPositionInGroup = 3;
                    break;
                case ConsignmentState.DeliveryFailed:
                    radial.UiGroup = 3;
                    radial.UiPositionInGroup = 4;
                    break;
                case ConsignmentState.ReturnToSender:
                    radial.UiGroup = 3;
                    radial.UiPositionInGroup = 5;
                    break;
            }
            return radial;
        }
    }
}