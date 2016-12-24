using System.Collections.Generic;

namespace Spa.StarterKit.React.ViewModels.Dashboard
{
    public class MixedChartViewModel
    {
        public MixedChartViewModel()
        {
            Labels = new List<string>();
            Datasets = new List<MixedChartDatasetViewModel>();
        }

        public IList<MixedChartDatasetViewModel> Datasets { get; set; }
        public IList<string> Labels { get; set; }
    }
}
