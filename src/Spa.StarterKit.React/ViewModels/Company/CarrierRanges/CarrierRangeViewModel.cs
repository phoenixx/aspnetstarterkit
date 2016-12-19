using System.Collections.Generic;

namespace Spa.StarterKit.React.ViewModels.Company.CarrierRanges
{
    public class CarrierRangeViewModel
    {
        /// <summary>
        /// The data that determines the start and end of the range, whether it 
        /// is current or not and it's order to be used in when not a circular 
        /// range.
        /// </summary>
        public virtual IList<RangeViewModel> Ranges { get; set; }

        /// <summary>
        /// Determines if the range will loop around to the start when it reaches the end or if it
        /// can switch to another range or stop once it reaches it's end value 
        /// </summary>
        public bool IsCircular { get; set; }


        /// <summary>
        /// Specifies if this Carrier Range is used as a template for data spcific sequences
        /// </summary>
        public bool IsTemplate { get; set; }

        /// <summary>
        /// This is the name used to determine how the range is used - i.e. barcode, filename, etc.
        /// </summary>
        public string RangeName { get; set; }

        /// <summary>
        /// This is the text used to describe what the range is used for - i.e. DPD's parcel counter for SLID
        /// </summary>
        public string RangeDescription { get; set; }
    }
}