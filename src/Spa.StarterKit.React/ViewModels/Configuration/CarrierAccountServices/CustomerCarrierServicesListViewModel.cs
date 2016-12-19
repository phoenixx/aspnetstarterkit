using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Spa.StarterKit.React.ViewModels.Configuration.CarrierServiceGroups;

namespace Spa.StarterKit.React.ViewModels.Configuration.CarrierAccountServices
{
    public class CustomerCarrierServicesListViewModel
    {
        public const int DefaultPageSize = 25;

        [DataMember]
        public int PageSize => DefaultPageSize;

        public IEnumerable<CarrierServiceViewModel> CarrierServices { get; set; }
        public int TotalRecords { get; set; }
        public Guid Customer { get; set; }
        public string Carrier { get; set; }
    }
}