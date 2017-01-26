using System.Threading.Tasks;
using Spa.StarterKit.React.ViewModels.Tracking;

namespace Spa.StarterKit.React.Services.Interfaces
{
    public interface ITrackingService
    {
        Task<TrackingViewModel> GetTrackingEventsAsync(string consignmentReference);
    }
}