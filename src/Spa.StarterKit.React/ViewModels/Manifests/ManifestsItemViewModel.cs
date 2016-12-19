using System;

namespace Spa.StarterKit.React.ViewModels.Manifests
{
    public class ManifestsItemViewModel
    {
        public string Reference { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateSent { get; set; }
        public string Carrier { get; set; }
        public int NumberOfPackages { get; set; }
    }
}