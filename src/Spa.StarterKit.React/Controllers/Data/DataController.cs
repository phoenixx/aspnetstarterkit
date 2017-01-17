using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Spa.StarterKit.React.Services.Interfaces;

namespace Spa.StarterKit.React.Controllers.Data
{
    public class DataController : Controller
    {
        private readonly IStaticDataService _staticDataService;

        public DataController(IStaticDataService staticDataService)
        {
            _staticDataService = staticDataService;
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
    }
}