using System.Collections.Generic;

namespace Spa.StarterKit.React.ViewModels.Company.CarrierRanges
{
   
    public class ManageCarrierRangesViewModel
    {
        /// <summary>
        /// List that determines the range(s) for each type or range we can store (barcodes, filename, etc)
        /// </summary>
        public virtual IList<CarrierRangeViewModel> CarrierRanges { get; set; }

        /// <summary>
        /// The carrier that the carrier account reference is to be used with
        /// and also used to name the underlying SQL Server sequence
        /// </summary>
        public string CarrierReference { get; set; } // Dpd
        /// <summary>
        /// The customer that owns the carrier account reference
        /// </summary>
        public string CustomerReference { get; set; } // internal guid class - use this for security check!!!!
        /// <summary>
        /// The carrier account reference the range(s) will be used with
        /// and also used to name the underlying SQL Server sequence
        /// </summary>
        public string CarrierAccountReference { get; set; } // e.g. DYSON_DPDCON1 

        /// <summary>
        /// The Id for a Carrier Service's GatewayType.
        /// </summary>
        public int GatewayTypeId { get; set; } 
    }
}