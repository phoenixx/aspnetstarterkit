using System.Collections.Generic;
using MPD.Electio.SDK.NetCore.DataTypes.Common.v1_1;

namespace Spa.StarterKit.React.ViewModels.Configuration.CarrierAccounts
{
    public class EditCarrierAccountViewModel
    {
        public class CarrierAccountViewModel
        {
            public string Reference { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public string Customer { get; set; }
            public string RatesExternalReference { get; set; }
            public string CarrierBookingExternalReference { get; set; }
            public string TrackingExternalReference { get; set; }
            public string ServiceAvailabilityExternalReference { get; set; }
        }

        public CarrierAccountViewModel CarrierAccount { get; set; }

        public List<SelectOption> Customers { get; set; }
    }
}