using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MPD.Electio.SDK.NetCore.DataTypes.Profile.v1_1;
using Spa.StarterKit.React.Services.Interfaces;

namespace Spa.StarterKit.React.Controllers.Dashboard
{
    public class DashboardController : Controller
    {
        private readonly IDashboardService _dashboardService;

        public DashboardController(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

#warning fixed const should be config
        private const int DAYS_DATA_TO_DISPLAY = 30;

        [Route("dashboard/predespatch")]
        public async Task<IActionResult> PreDespatch(DateTime? from, DateTime? to, string shippingLocationReference)
        {
            if (from.HasValue && to.HasValue && (from.Value == to.Value)) //single date period
            {
                from = from.Value.Date;
                to = to.Value.Date.AddHours(23).AddMinutes(59);
            }

            if (!from.HasValue)
            {
                from = DateTime.Now.AddDays(-DAYS_DATA_TO_DISPLAY);
            }

            to = to?.AddDays(1) ?? DateTime.Now.AddDays(1);

            var shippingLocationWhiteList = User.Claims.Where(x => x.Type == "ShippingLocation").Select(x => new ShippingLocation()
            {
                Name = x.Value,
                Reference = x.Value
            }).ToList();

            var dashboard = await _dashboardService.GetDashboard(from.Value, to.Value, shippingLocationWhiteList, shippingLocationReference);
            //var dashboard = await _dashboardService.GetPreDespatchDashboard(from.Value, to.Value, shippingLocationWhiteList, shippingLocationReference);

           return Json(dashboard);
        }
    }
}
