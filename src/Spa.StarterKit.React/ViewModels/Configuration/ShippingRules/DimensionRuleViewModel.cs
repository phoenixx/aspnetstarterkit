using System.Collections.Generic;

namespace Spa.StarterKit.React.ViewModels.Configuration.ShippingRules
{
    public class DimensionRuleViewModel
    {
        public DimensionRuleViewModel()
        {
            Ranges = new List<Range>();
        }

        public string Unit { get; set; }

        public IList<Range> Ranges { get; set; }

        public class Range
        {
            public int Id { get; set; }
            public decimal From { get; set; }
            public decimal To { get; set; }
        }
    }
}