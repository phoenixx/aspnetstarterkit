using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Spa.StarterKit.React.Services.Interfaces;

namespace Spa.StarterKit.React.Controllers.Tracking
{
    public class TrackingController : Controller
    {
        private readonly ITrackingService _trackingService;

        public TrackingController(ITrackingService trackingService)
        {
            _trackingService = trackingService;
        }

        [Route("tracking/{consignmentReference}")]
        public async Task<IActionResult> TrackingEvents(string consignmentReference)
        {
            var getEvents = _trackingService.GetTrackingEventsAsync(consignmentReference);
            var events = await getEvents;

            if (events != null && events.TrackedPackages.Any())
            {
                return Json(new { events = events.TrackedPackages});
            }
            return Json(new {events = new List<string>(0)});
        }
    }
}