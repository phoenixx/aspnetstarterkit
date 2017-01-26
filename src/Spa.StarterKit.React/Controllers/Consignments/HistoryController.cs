using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Spa.StarterKit.React.Services.Interfaces;

namespace Spa.StarterKit.React.Controllers.Consignments
{
    public class HistoryController : Controller
    {
        private readonly IConsignmentService _consignmentService;

        public HistoryController(IConsignmentService consignmentService)
        {
            _consignmentService = consignmentService;
        }

        [Route("history/{consignmentReference}")]
        public async Task<IActionResult> ConsignmentHistory(string consignmentReference)
        {
            var getHistory = _consignmentService.GetAuditMessagesForConsignmentAsync(consignmentReference);
            var history = await getHistory;
            return Json(history);
        }
    }
}