using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Spa.StarterKit.React.Services.Interfaces;
using Spa.StarterKit.React.ViewModels.Tracking;

namespace Spa.StarterKit.React.Services
{
    public class TrackingService : ITrackingService
    {
        private readonly MPD.Electio.SDK.NetCore.Interfaces.v1_1.Services.ITrackingService _trackingApiService;
        private readonly IMapper _mapper;

        public TrackingService(
            MPD.Electio.SDK.NetCore.Interfaces.v1_1.Services.ITrackingService trackingApiService,
            IMapper mapper)
        {
            _trackingApiService = trackingApiService;
            _mapper = mapper;
        }

        public async Task<TrackingViewModel> GetTrackingEventsAsync(string consignmentReference)
        {
            try
            {
                var results =
                await _trackingApiService.GetTrackingEventsForEachPackageByConsignmentAsync(consignmentReference)
                    .ConfigureAwait(false);
                return _mapper.Map<TrackingViewModel>(results);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new TrackingViewModel()
                {
                    ConsignmentReferenceForAllLegsAssignedByMpd = consignmentReference,
                    TrackedPackages = new List<TrackedPackageViewModel>(0)
                };
            }
        }
    }
}