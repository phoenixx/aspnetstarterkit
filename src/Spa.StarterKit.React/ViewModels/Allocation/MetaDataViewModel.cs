using System;

namespace Spa.StarterKit.React.ViewModels.Allocation
{
    public class MetaDataViewModel
    {
        public string KeyValue { get; set; }
        public string StringValue { get; set; }
        public int? IntValue { get; set; }
        public decimal? DecimalValue { get; set; }
        public DateTime? DateTimeValue { get; set; }
        public bool? BoolValue { get; set; }

        public string GetValueAsString()
        {
            if (this.StringValue != null)
                return this.StringValue;
            else if (this.IntValue.HasValue)
                return this.IntValue.Value.ToString();
            else if (this.DecimalValue.HasValue)
                return this.DecimalValue.Value.ToString();
            else if (this.DateTimeValue.HasValue)
                return this.DateTimeValue.Value.ToString();
            else if (this.BoolValue.HasValue)
                return this.BoolValue.Value.ToString();
            else
                return "";
        }
    }
}
