using System;

namespace Spa.StarterKit.React.ViewModels.Configuration.Rates
{
    public class RatesTemplateViewModel
    {
        public Guid Reference { get; set; }
        public int VersionNumber { get; set; }
        public string MpdCarrierServiceReference { get; set; }
        public byte[] FileContents { get; set; }
    }
}