using System;
using MPD.Electio.SDK.NetCore.DataTypes.Common.v1_1;

namespace Spa.StarterKit.React.ViewModels.Company
{
    public class OutstandingChargeViewModel
    {
        public string InvoiceReference { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string YourReference { get; set; }
        public string ConsignmentReference { get; set; }
        public Address OriginAddress { get; set; }
        public Address DestinationAddress { get; set; }
        public string CarrierService { get; set; }
        public decimal Amount { get; set; }
        public bool IsSelected { get; set; }
    }
}
