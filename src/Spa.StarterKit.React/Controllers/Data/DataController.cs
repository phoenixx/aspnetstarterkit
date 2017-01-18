using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Spa.StarterKit.React.Services.Interfaces;

namespace Spa.StarterKit.React.Controllers.Data
{
    public class DataController : Controller
    {
        private readonly IStaticDataService _staticDataService;
        private readonly IShippingLocationService _shippingLocationService;

        public DataController(
            IStaticDataService staticDataService,
            IShippingLocationService shippingLocationService)
        {
            _staticDataService = staticDataService;
            _shippingLocationService = shippingLocationService;
        }

        [Route("data/titles")]
        public async Task<IActionResult> Titles()
        {
            var titles = await _staticDataService.GetTitles();
            return Json(titles);
        }

        [Route("data/countries")]
        public async Task<IActionResult> Countries()
        {
            var countries = await _staticDataService.GetCountries();
            return Json(countries);
        }

        [Route("data/shippinglocations/assigned")]
        public async Task<IActionResult> AssignedShippingLocations()
        {
            var result = await _shippingLocationService.GetAssignedShippingLocations();
            return Json(result);
        }
    }
}