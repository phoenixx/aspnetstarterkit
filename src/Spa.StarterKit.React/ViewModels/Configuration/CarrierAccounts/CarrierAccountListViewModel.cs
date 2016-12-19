using System.Collections.Generic;
using System.Runtime.Serialization;
using MPD.Electio.SDK.NetCore.Internal.DataTypes.Carriers;

namespace Spa.StarterKit.React.ViewModels.Configuration.CarrierAccounts
{
    public class CarrierAccountListViewModel
    {
        public const int DefaultPageSize = 25;

        [DataMember]
        public int PageSize => DefaultPageSize;

        public IEnumerable<CarrierAccount> CarrierAccounts { get; set; }
        public int TotalRecords { get; set; }
    }
}