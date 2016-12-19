using System.Collections.Generic;
using MPD.Electio.SDK.NetCore.DataTypes.Common.v1_1;
using Spa.StarterKit.React.Models;

namespace Spa.StarterKit.React.ViewModels.Company
{
    public class CarrierServiceSetsViewModel : SortableModel
    {
        public IList<MpdCarrierServiceGroup> CarrierServiceSets { get; set; }
    }
}