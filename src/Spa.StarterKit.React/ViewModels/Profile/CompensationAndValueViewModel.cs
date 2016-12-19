using System.ComponentModel.DataAnnotations;
using Spa.StarterKit.React.ViewModels.CustomValidationAttributes;

namespace Spa.StarterKit.React.ViewModels.Profile
{
    [CompensationAndValueValidation]
    public class CompensationAndValueViewModel
    {
        public int Id { get; set; }
        public decimal? CompensationThreshold { get; set; }
        public bool GetEnhancedCompensation { get; set; }
        [Range(1d, double.MaxValue, ErrorMessage = "Allowed parcel value cannot be less than 1.")]
        public decimal? MaxParcelValue { get; set; }
    }
}