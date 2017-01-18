using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MPD.Electio.SDK.NetCore.DataTypes.Profile.v1_1;
using MPD.Electio.SDK.NetCore.Interfaces.v1_1.Services;
using Spa.StarterKit.React.Models;
using Spa.StarterKit.React.Services.Interfaces;

namespace Spa.StarterKit.React.Services
{
    public class ShippingLocationService : IShippingLocationService
    {
        private readonly IShippingLocationsService _shippingLocationsService;

        public ShippingLocationService(IShippingLocationsService shippingLocationsService)
        {
            _shippingLocationsService = shippingLocationsService;
        }

        public async Task<List<ShippingLocation>> GetShippingLocations()
        {
            return await _shippingLocationsService.GetShippingLocationsAsync();
        }

        public async Task<List<ShippingLocation>> GetAssignedShippingLocations()
        {
            return await _shippingLocationsService.GetAssignedShippingLocationsAsync();
        }

        public Task<ShippingLocation> GetShippingLocation(string shippingLocationReference)
        {
            throw new NotImplementedException();
        }

        public bool EditShippingLocation(ShippingLocation model)
        {
            throw new NotImplementedException();
        }

        public ApiResult CreateShippingLocation(ShippingLocation model)
        {
            throw new NotImplementedException();
        }

        public bool DeleteShippingLocation(string shippingLocationReference)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsShippingLocationReferenceAvailable(string shippingLocationReference)
        {
            throw new NotImplementedException();
        }
    }
}
