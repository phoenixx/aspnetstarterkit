using System.Collections.Generic;
using MPD.Electio.SDK.NetCore.DataTypes.Consignments.v1_1;

namespace Spa.StarterKit.React.ViewModels.Manifests
{
    public class ManifestsViewModel
    {
        public IList<ManifestFileInfo> ManifestItems { get; set; }
    }
}