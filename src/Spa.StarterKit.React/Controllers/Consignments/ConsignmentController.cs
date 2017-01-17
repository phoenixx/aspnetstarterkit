using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Spa.StarterKit.React.Services.Interfaces;

namespace Spa.StarterKit.React.Controllers.Consignments
{
    public class ConsignmentController : Controller
    {
        private readonly IConsignmentService _consignmentService;

        public ConsignmentController(IConsignmentService consignmentService)
        {
            _consignmentService = consignmentService;
        }

        [Route("consignment/{consignmentReference}")]
        public async Task<IActionResult> LoadConsignment(string consignmentReference)
        {
            var consignment = await _consignmentService.GetConsignment(consignmentReference);
            return Json(consignment);
        }
    }
}