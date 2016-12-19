using System.Collections.Generic;
using System.Linq;

namespace Spa.StarterKit.React.ViewModels.Shared.CarriersAndServices
{
    public class SimpleCarrierViewModel
    {
        public SimpleCarrierViewModel()
        {
            CarrierServices = new List<SimpleCarrierServiceViewModel>();
        }

        public int Id { get; set; }
        public string Reference { get; set; }
        public string Name { get; set; }
        public IList<SimpleCarrierServiceViewModel> CarrierServices { get; set; }

        public bool HasSelectedServices
        {
            get { return CarrierServices.Any(s => s.Selected); }
        }
    }
}