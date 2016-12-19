using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Spa.StarterKit.React.ViewModels.CustomValidationAttributes;

namespace Spa.StarterKit.React.ViewModels.Configuration.Zones
{
    [ZoneValidation]
    public class ZoneViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Reference { get; set; }

        [Required]
        public string Label { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public bool Deleted { get; set; }

        public List<EndpointViewModel> Endpoints { get; set; }

        public List<ServiceViewModel> Services { get; set; }

        public class ServiceViewModel
        {
            public string Label { get; set; }
            public string Reference { get; set; }
            public string ServiceType { get; set; }
        }
        
    }
}