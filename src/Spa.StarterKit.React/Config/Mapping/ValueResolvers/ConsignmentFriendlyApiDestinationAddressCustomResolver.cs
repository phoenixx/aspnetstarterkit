using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using MPD.Electio.SDK.NetCore.DataTypes.Consignments.v1_1;
using MPD.Electio.SDK.NetCore.DataTypes.Consignments.v1_1.Enums;
using Spa.StarterKit.React.ViewModels.Allocation;

namespace Spa.StarterKit.React.Config.Mapping.ValueResolvers
{
    public class ConsignmentFriendlyApiDestinationAddressCustomResolver : IValueResolver<Consignment, ConsignmentDetailViewModel, string>
    {
        private static string GenerateFriendlyAddress(MPD.Electio.SDK.NetCore.DataTypes.Common.v1_1.Address address)
        {
            if (address == null)
            {
                return string.Empty;
            }

            var fields = new List<string>
            {
                address.AddressLine1,
                address.Town,
                address.Postcode,
                address.Country.IsoCode.TwoLetterCode
            };

            return string.Join(", ", fields);
        }

        public string Resolve(Consignment source, ConsignmentDetailViewModel destination, string destMember, ResolutionContext context)
        {
            var destinationAddress =
                source.Addresses.SingleOrDefault(
                    x => x.AddressType == ConsignmentAddressType.Destination);
            return destination == null ? string.Empty : GenerateFriendlyAddress(destinationAddress);
        }
    }
}