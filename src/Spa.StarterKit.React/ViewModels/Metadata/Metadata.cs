using System.Collections.Generic;

namespace Spa.StarterKit.React.ViewModels.Metadata
{
    public class Metadata
    {
        public MetadataType Type { get; set; }
        public string Reference { get; set; }
        public IList<MetadataItem> Items { get; set; }
    }
}