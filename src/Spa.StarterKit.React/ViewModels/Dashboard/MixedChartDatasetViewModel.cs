using System.Collections.Generic;

namespace Spa.StarterKit.React.ViewModels.Dashboard
{
    public class MixedChartDatasetViewModel
    {
        public MixedChartDatasetViewModel()
        {
            Values = new List<double>();
        }

        public IList<double> Values { get; set; }
        public string Label { get; set; }
    }
}