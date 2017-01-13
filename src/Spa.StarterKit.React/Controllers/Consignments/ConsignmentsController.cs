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

        [Route("consignments/shipped")]
        public async Task<IActionResult> Shipped(int skip = 0, int take = 10)
        {
            return await Consignments(ConsignmentStateType.Shipped, null, skip, take);
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
    }
}