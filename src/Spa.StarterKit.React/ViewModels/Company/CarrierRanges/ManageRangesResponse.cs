using System.Collections.Generic;
using MPD.Electio.SDK.NetCore.DataTypes.Common.v1_1;

namespace Spa.StarterKit.React.ViewModels.Company.CarrierRanges
{
    public class ManageRangesResponse
    {
        public List<ValidationError> ValidationErrors { get; set; }
        public bool IsSuccess { get; set; }
    }
}