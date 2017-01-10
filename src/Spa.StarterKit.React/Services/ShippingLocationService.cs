using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MPD.Electio.SDK.NetCore.DataTypes.Profile.v1_1;
using Spa.StarterKit.React.Models;
using Spa.StarterKit.React.Services.Interfaces;

namespace Spa.StarterKit.React.Services
{
    public class ShippingLocationService : IShippingLocationService
    {
        public async Task<List<ShippingLocation>> GetShippingLocations()
        {
            return await Task.Run(() => new List<ShippingLocation>());
        }

        public async Task<List<ShippingLocation>> GetAssignedShippingLocations()
        {
            return await Task.Run(() => new List<ShippingLocation>());
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
