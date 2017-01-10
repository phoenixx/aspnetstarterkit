using System.Collections.Generic;
using System.Threading.Tasks;
using MPD.Electio.SDK.NetCore.DataTypes.Profile.v1_1;
using Spa.StarterKit.React.Models;

namespace Spa.StarterKit.React.Services.Interfaces
{
    public interface IShippingLocationService
    {
        Task<List<ShippingLocation>> GetShippingLocations();
        Task<List<ShippingLocation>> GetAssignedShippingLocations();
        Task<ShippingLocation> GetShippingLocation(string shippingLocationReference);
        bool EditShippingLocation(ShippingLocation model);
        ApiResult CreateShippingLocation(ShippingLocation model);
        bool DeleteShippingLocation(string shippingLocationReference);
        Task<bool> IsShippingLocationReferenceAvailable(string shippingLocationReference);
    }
}