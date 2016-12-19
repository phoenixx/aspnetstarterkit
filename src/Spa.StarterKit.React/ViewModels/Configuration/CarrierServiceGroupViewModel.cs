using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Spa.StarterKit.React.ViewModels.CustomValidationAttributes;
using Spa.StarterKit.React.ViewModels.Shared.CarriersAndServices;

namespace Spa.StarterKit.React.ViewModels.Configuration
{
    [CarrierServiceGroupValidation]
    public class CarrierServiceGroupViewModel : CarrierServiceSelectionByCarriersViewModel
    {
        public Guid CompanyReference { get; set; }

        [Required(ErrorMessage = @"Please enter service group code")]
        [Remote("IsCarrierServiceGroupRefAvailable", "IsCarrierServiceGroupRefAvailable", ErrorMessage = "Already in use, choose another")]
        public string Reference { get; set; }

        [Required(ErrorMessage = @"Please enter service name")]
        public string Name { get; set; }

        public bool IsCreateMode { get; set; }

        public List<string> ExistingGroupReferences { get; set; }
    }
}