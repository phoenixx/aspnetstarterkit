using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Spa.StarterKit.React.ViewModels.Configuration.Carriers
{
    public class CarrierListViewModel
    {
        public const int DefaultPageSize = 25;

        [DataMember]
        public int PageSize => DefaultPageSize;

        public IEnumerable<MPD.Electio.SDK.NetCore.DataTypes.CarrierServiceDirectory.v1_1.Carrier> Carriers { get; set; }
        public int TotalRecords { get; set; }
        public Guid Customer { get; set; }
    }
}